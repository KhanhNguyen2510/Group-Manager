using GM.API.Models.PackageProducts;

namespace GM.API.Services;
public interface IPackageProductService
{
    Task<PackageProduct> GetPackageProductByIdAsync(int packageProductId);
    Task<ApiResponse> Create(int managerId, CreatePackageProductModel request);
    Task<ApiResponse> Update(int managerId, int packageProductId, 
        UpdatePackageProductModel request);

    Task<ApiResponse> Delete(int managerId, int packageProductId);
    Task<ApiResponse> PackageProductById(int managerId, int packageProductId);
    Task<ApiResponse> PackageProducts(int managerId, GetPackageProductsModel request);

    Task<ApiResponse> CreateDetail(int managerId, int packageProductId,
        CreatePackageProductDetailModel request);

    Task<ApiResponse> UpdateDetail(int managerId, int packageProductId, int productId,
        UpdatePackageProductDetailModel request);

    Task<ApiResponse> DeleteDetail(int managerId, int packageProductId, int productId);
    Task<ApiResponse> PackageProductDetailById(int managerId, int packageProductId, int productId);

    Task<ApiResponse> PackageProductDetails(int managerId,int packageProductId, 
        PackageProductDetailsModel request);
}
public class PackageProductService : IPackageProductService
{
    private readonly IPackageProductRepository _packageProductRepository;
    private readonly IUserService _userService;
    private readonly IProductService _productService;
    private readonly IPackageProductDetailRepository _packageProductDetailRepository;
    private readonly IProductRepository _productRepository;

    public PackageProductService(
        IPackageProductDetailRepository packageProductDetailRepository,
        IPackageProductRepository packageProductRepository,
        IUserService userService,
        IProductService productService,
        IProductRepository productRepository
        )
    {
        _packageProductDetailRepository = packageProductDetailRepository;
        _packageProductRepository = packageProductRepository;
        _userService = userService;
        _productService = productService;
        _productRepository = productRepository;
    }

    // bỏ ngày bắt đầu và ngày kết thúc 
    private async Task UpdateTotalAmount(List<Products> lProduct, PackageProduct packageProduct, int managerId)
    { 
         decimal totalAmount = 0;
        
        var packageDetails = new List<PackageProductDetail>();

        var productIds = lProduct.Select(x => x.productId);

        var products = await _productRepository.FindAsync(new Expression<Func<Product, bool>>[]
        {
            p => productIds.Contains(p.Id)
        }, string.Empty, string.Empty);

        if (products.Any(p => !productIds.Contains(p.Id))) 
            throw new ApiException(
                ApiMessage.NotFound,ErrorCode.NOT_FOUND);

        foreach (var item in lProduct)
        {
            var product = products.FirstOrDefault(x => x.Id == item.productId);
            if (product == null) continue;

            var packageProductDetail = packageDetails.FirstOrDefault(x => x.PackageProductId == packageProduct.Id 
            && x.ProductId == item.productId);

            var price = product.Price * item.quantity;
            
            if (packageProductDetail != null)
            {

                packageProductDetail.Price += price;
                packageProductDetail.Quantity += item.quantity;

            }
            else
            {
                var data = new PackageProductDetail
                {
                    ProductId = item.productId,
                    PackageProductId = packageProduct.Id,
                    Quantity = item.quantity,
                    Price = price,
                    CreatorId = managerId
                };

                packageDetails.Add(data);
 
            }
            totalAmount += price;
        }

        packageProduct.TotalAmount = totalAmount;

        _packageProductRepository.Update(packageProduct);
        await _packageProductRepository.SaveChangeAsync();

        await _packageProductDetailRepository.InsertAsync(packageDetails);
        await _packageProductDetailRepository.SaveChangeAsync();
    }
    
    public async Task<ApiResponse> Create(int managerId, CreatePackageProductModel request)
    {
        var startDate = DateTime.Now;
        var endDate = startDate.AddDays(request.duration); 
        
        var data = new PackageProduct
        {
            Name = request.name,
            Note = request.note,
            StartDate = startDate,
            EndDate = endDate,
            Duration = request.duration,
            CreatorId = managerId
        };
        
        await _packageProductRepository.InsertAsync(data);
        await _packageProductRepository.SaveChangeAsync();

        if (request.products is { Count: > 0 })
        {
            await UpdateTotalAmount(request.products, data, managerId);
        }

        return ApiResponse.Success();
    }
    
    public async Task<PackageProduct> GetPackageProductByIdAsync(int packageProductId)
    {
        var packageById = await _packageProductRepository.FindOneAsync(new Expression<Func<PackageProduct, bool>>[]
        {
            x => x.IsDeleted == false
                 && x.Id == packageProductId
        }, "PackageProductDetails");

        if (packageById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);

        return packageById;
    }

    public async Task<ApiResponse> Update(int managerId ,int packageProductId, UpdatePackageProductModel request)
    {
        var packageById = await GetPackageProductByIdAsync(packageProductId);
        var managerById = await _userService.GetUserByIdAsync(managerId);
        
        if (managerById.Role == UserRole.Nco)
        {
            if (packageById.CreatorId != managerId) 
                throw new ApiException(
                    ApiMessage.NotRole, ErrorCode.NOT_ROLE);
        }

        if (request.duration is > 0)
        {
            packageById.EndDate = packageById.StartDate.AddDays((int)request.duration);
            packageById.Duration = (int)request.duration;
        }

        packageById.Name = request.name ?? packageById.Name;
        packageById.Note = request.note ?? packageById.Note;
        packageById.UpdateDate = DateTime.Now;

        _packageProductRepository.Update(packageById);
        await _packageProductRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<List<PackageProductDetail>> GetPackageProductDetailsAsync(int packageProductId)
    {
        return await _packageProductDetailRepository.FindAsync(new Expression<Func<PackageProductDetail, bool>>[]
            {
                x => x.IsDeleted == false 
                     && x.PackageProductId == packageProductId
            },
            string.Empty, string.Empty);
    }

    public async Task<ApiResponse> Delete(int managerId,int packageProductId )
    {
        var packageById = await GetPackageProductByIdAsync(packageProductId);
        var managerById = await _userService.GetUserByIdAsync(managerId);
        var packageDetailById = await GetPackageProductDetailsAsync(packageProductId);
        
        if (managerById.Role == UserRole.Nco)
        {
            if (packageById.CreatorId != managerId) 
                throw new ApiException(
                    ApiMessage.NotRole, ErrorCode.NOT_ROLE);
        }

        if (packageDetailById != null)
        {
            var data = new List<PackageProductDetail>();
            Parallel.ForEach(packageDetailById, item =>
            {
                item.IsDeleted = true;
                item.UpdateDate = DateTime.Now;
                item.TimeDelete = DateTime.Now;
                data.Add(item);
            });

            _packageProductDetailRepository.Update(data);
            await _packageProductDetailRepository.SaveChangeAsync();
        }
        
        packageById.IsDeleted = true;
        packageById.TimeDelete = DateTime.Now;
        packageById.UpdateDate = DateTime.Now;

        _packageProductRepository.Update(packageById);           
        await _packageProductRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> PackageProductById(int managerId,int packageProductId)
    {
        var packageById = await GetPackageProductByIdAsync(packageProductId);


        return ApiResponse.Success(packageById);
    }

    private async Task<List<Expression<Func<PackageProduct, bool>>>> QueryPackageProduct(int managerId,
        GetPackageProductsModel request)
    {
        var query = new List<Expression<Func<PackageProduct, bool>>>() { x => x.IsDeleted == false };

        var manager = await _userService.GetUserByIdAsync(managerId);

        if (manager.Role == UserRole.Nco)
            query.Add(x => x.CreatorId == managerId);

        if (!string.IsNullOrEmpty(request.Keyword))
            query.Add(x => x.Name.Contains(request.Keyword)
                           || x.Note.Contains(request.Keyword)
                           || x.Id.ToString().Contains(request.Keyword));
        return query;
    }

    public async Task<ApiResponse> PackageProducts(int managerId, GetPackageProductsModel request)
    {
        var query = await QueryPackageProduct(managerId, request);
        var packageProducts = await _packageProductRepository.FindIncludeAsync(query.ToArray(),
            request.OrderBy, "PackageProductDetails", request.Skip(), request.PageCount);

        return ApiResponse.Success(packageProducts.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = packageProducts.TotalCount,
            Page = request.Page
        });
    }

    public async Task<ApiResponse> CreateDetail( int managerId,int packageProductId,
        CreatePackageProductDetailModel request)
    {
        var manager = await _userService.GetUserByIdAsync(managerId);
        var productById = await _productService.GetProductByIdAsync(request.productId);
        var packageById = await GetPackageProductByIdAsync(packageProductId);
        var packageDetail = await GetPackageProductDetailAsync(packageProductId, request.productId);
        if (manager.Role == UserRole.Nco)
        {
            if (
                packageById.CreatorId != managerId)
                throw new ApiException(
                    ApiMessage.NotRole, ErrorCode.NOT_ROLE);
        }

        if (packageDetail != null)
        {
            packageDetail.Quantity += request.quantity;
            packageDetail.UpdateDate = DateTime.Now;
            _packageProductDetailRepository.Update(packageDetail);
        }
        else
        {
            var data = new PackageProductDetail
            {
                PackageProductId = packageProductId,
                ProductId = request.productId,
                CreatorId = managerId,
                Quantity = request.quantity
            };

            await _packageProductDetailRepository.InsertAsync(data);
        }

        packageById.TotalAmount += productById.Price * request.quantity;

        _packageProductRepository.Update(packageById);
        await _packageProductRepository.SaveChangeAsync();

        await _packageProductDetailRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<PackageProductDetail> GetPackageProductDetailAsync(int packageProductId, int productId)
    {
        return await _packageProductDetailRepository.FindOneAsync(
            new Expression<Func<PackageProductDetail, bool>>[]
            {
                p => p.IsDeleted == false
                     && p.ProductId == productId
                     && p.PackageProductId == packageProductId
            });
    }

    public async Task<ApiResponse> UpdateDetail(int managerId,int packageProductId, int productId, 
        UpdatePackageProductDetailModel request)
    {
        var manager = await _userService.GetUserByIdAsync(managerId);
        var packageDetailById = await GetPackageProductDetailAsync(packageProductId, productId);
        var productById = await _productService.GetProductByIdAsync(productId);
        var packageById = await GetPackageProductByIdAsync(packageProductId);
        if (packageDetailById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        if (manager.Role == UserRole.Nco)
        {
            if ( packageById.CreatorId != managerId)
                throw new ApiException(
                    ApiMessage.NotRole, ErrorCode.NOT_ROLE);
        }

        packageById.TotalAmount -= packageDetailById.Quantity * productById.Price; //Xóa trong database món hàng đó
        packageById.TotalAmount += productById.Price * request.quantity; // Thêm vào database 
        packageById.UpdateDate = DateTime.Now;

        packageDetailById.Quantity = request.quantity;
        packageDetailById.UpdateDate = DateTime.Now;

        _packageProductRepository.Update(packageById);
        await _packageProductRepository.SaveChangeAsync();

        _packageProductDetailRepository.Update(packageDetailById);
        await _packageProductDetailRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> DeleteDetail(int managerId,int packageProductId, int productId)
    {
        var manager = await _userService.GetUserByIdAsync(managerId);
        var packageDetail = await GetPackageProductDetailAsync(packageProductId, productId);
        var productById = await _productService.GetProductByIdAsync(productId);
        var packageProduct = await GetPackageProductByIdAsync(packageProductId);
        if (manager.Role == UserRole.Nco)
        {
            if (productById.ManagerId != managerId
                || packageDetail.CreatorId != managerId)
                throw new ApiException("Không thêm được thông tin này", ErrorCode.NOT_ROLE);
        }

        packageProduct.TotalAmount -= (packageDetail.Quantity * productById.Price);
        packageProduct.IsDeleted = true;
        packageProduct.UpdateDate = DateTime.Now;
        packageProduct.TimeDelete = DateTime.Now;

        _packageProductRepository.Update(packageProduct);
        await _packageProductRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> PackageProductDetailById(int managerId,int packageProductId, int productId)
    {
        var manager = await _userService.GetUserByIdAsync(managerId);
        var packageProductDetail = await GetPackageProductDetailAsync(packageProductId, productId);
        if (manager.Role == UserRole.Nco)
        {
            if (packageProductDetail.CreatorId != managerId)
                throw new ApiException("Không có quyền xem thông tin này", ErrorCode.NOT_ROLE);
        }

        if (packageProductDetail == null)
            throw new ApiException(ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return ApiResponse.Success(packageProductDetail);
    }

    private async Task<List<Expression<Func<PackageProductDetail, bool>>>> QueryPackageProductDetails(
        int packageProductId, int managerId,
        PackageProductDetailsModel request)
    {
        var query = new List<Expression<Func<PackageProductDetail, bool>>>()
        {
            x => x.IsDeleted == false
            && x.PackageProductId == packageProductId
        };
        var manager = await _userService.GetUserByIdAsync(managerId);
        if (manager.Role == UserRole.Nco)
            query.Add(x => x.CreatorId == managerId);
        if (request.managerId != null )
            query.Add(x => x.CreatorId == managerId);
        if (request.productId != null)
            query.Add(x => x.ProductId == request.productId);
        if (request.packageproductId != null)
            query.Add(x => x.PackageProductId == request.packageproductId);
        return query;
    }

    public async Task<ApiResponse> PackageProductDetails(int managerId, int packageProductId ,
        PackageProductDetailsModel request)
    {
        var query = await QueryPackageProductDetails(packageProductId, managerId, request);

        var packageProducts = await _packageProductDetailRepository.FindAsync(query.ToArray(),
            request.OrderBy, request.Skip(), request.PageCount);

        return ApiResponse.Success(packageProducts.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = packageProducts.TotalCount,
            Page = request.Page
        });
    }
}
