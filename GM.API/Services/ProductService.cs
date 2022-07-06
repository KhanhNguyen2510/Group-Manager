using GM.API.Models.Products;

namespace GM.API.Services;

public interface IProductService
{
    Task<Product> GetProductByIdAsync(int productId);
    Task<ApiResponse> ProductById(int productId);
    Task<List<Product>> Products();
    Task<ApiResponse> Products(GetProductsModel request);
    Task<ApiResponse> Create(int managerId, CreateProductModel request);
    Task<ApiResponse> Update(int productId, UpdateProductModel request);
    Task<ApiResponse> Delete(int productId);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ApiResponse> Create(int managerId, CreateProductModel request)
    {
        var data = new Product
        {
            Name = request.name,
            Price = request.price,
            Note = request.note,
            ManagerId = managerId,
            CreatorId = managerId
        };

        await _productRepository.InsertAsync(data);
        await _productRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        var productById = await _productRepository.FindOneAsync(new Expression<Func<Product, bool>>[]
        {
            p => p.IsDeleted == false
                 && p.Id == productId
        });
        if (productById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return productById;
    }

    public async Task<ApiResponse> Update(int productId, UpdateProductModel request)
    {
        var productById = await GetProductByIdAsync(productId);

        productById.Name = request.name ?? productById.Name;
        productById.Price = request.price ?? productById.Price;
        productById.Note = request.note ?? productById.Note;
        productById.UpdateDate = DateTime.Now;

        _productRepository.Update(productById);
        await _productRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> Delete(int productId)
    {
        var productById = await GetProductByIdAsync(productId);

        productById.IsDeleted = true;
        productById.TimeDelete = DateTime.Now;
        productById.UpdateDate = DateTime.Now;

        _productRepository.Update(productById);
        await _productRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> ProductById(int productId)
    {
        var productById = await GetProductByIdAsync(productId);
        return ApiResponse.Success(productById);
    }

    private static Task<List<Expression<Func<Product, bool>>>> QueryProduct(GetProductsModel request)
    {
        var query = new List<Expression<Func<Product, bool>>> { x => x.IsDeleted == false };

        if (!string.IsNullOrEmpty(request.keyword))
            query.Add(x => x.Id.ToString().Contains(request.keyword)
                           || x.Name.Contains(request.keyword)
                           || x.Note.Contains(request.keyword));

        if (request.price != null)
            query.Add(x => x.Price == request.price);

        return Task.FromResult(query);
    }

    public async Task<List<Product>> Products()
    {
        var products = await _productRepository.FindAsync(new Expression<Func<Product, bool>>[]
        {
            x => x.IsDeleted == false
        }, string.Empty, string.Empty);

        return products;
    }

    public async Task<ApiResponse> Products(GetProductsModel request)
    {
        var query = await QueryProduct(request);

        var products = await _productRepository.FindAsync(query.ToArray(),
            request.OrderBy, request.Skip(), request.PageCount);

        return ApiResponse.Success(products.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = products.TotalCount,
            Page = request.Page
        });
    }
}
