using GM.API.Models.Invoices;

namespace GM.API.Services;

public interface IInvoiceService
{
    Task<List<InvoiceDetail>> GetInvoiceDetailsByIdAsync(int invoiceId);
    Task<Invoice> GetInvoiceByIdAsync(int creatorId, int invoiceId);
    Task<ApiResponse> InvoicesById(int creatorId, int invoiceId);
    Task<ApiResponse> Invoices(int creatorId, GetInvoicesModel request);
    Task<ApiResponse> Create(int managerId, CreateInvoiceModel request);
    Task<ApiResponse> Delete(int invoiceId, int creatorId);
}
public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IPackageProductService _packageProductService;
    private readonly IUserService _userService;
    private readonly INccService _nccService;
    private readonly INcService _ncService;
    private readonly IProductService _productService;
    private readonly IInvoiceDetailRepository _invoiceDetailRepository;
    public InvoiceService(
        IPackageProductService packageProductService,
        IProductService productService,
        IInvoiceRepository invoiceRepository,
        IInvoiceDetailRepository invoiceDetailRepository,
        IUserService userService,
        INccService nccService,
        INcService ncService
        )
    {
        _ncService = ncService;
        _invoiceDetailRepository = invoiceDetailRepository;
        _productService = productService;
        _packageProductService = packageProductService;
        _nccService = nccService;
        _invoiceRepository = invoiceRepository;
        _userService = userService;
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int creatorId,int invoiceId)
    {
        var invoiceById = await _invoiceRepository.FindOneAsync(new Expression<Func<Invoice, bool>>[]
        {
            p => p.IsDeleted == false 
                 && p.Id == invoiceId
                 && p.CreatorId == creatorId
        }, "InvoiceDetails");

        if (invoiceById == null) 
            throw new ApiException(
                ApiMessage.NotFound,ErrorCode.NOT_ALREDY_EXISTS);
        return invoiceById;
    }

    public async Task<List<InvoiceDetail>> GetInvoiceDetailsByIdAsync(int invoiceId)
    {
        return await _invoiceDetailRepository.FindAsync(new Expression<Func<InvoiceDetail, bool>>[]
        {
            x => x.IsDeleted == false 
                 && x.InvoiceId == invoiceId
        }, string.Empty, string.Empty);
    }

    public async Task<ApiResponse> InvoicesById( int creatorId,int invoiceId)
    {
        var invoicesById = await GetInvoiceByIdAsync( creatorId,invoiceId);

        return ApiResponse.Success(invoicesById);
    }

    private async Task<List<Expression<Func<Invoice, bool>>>> QueryInvoice(int creatorId, GetInvoicesModel request)
    {
        var query = new List<Expression<Func<Invoice, bool>>>()
        {
            x=>x.IsDeleted == false
        };

        var user = await _userService.GetUserByIdAsync(creatorId);
        if (user.Role == UserRole.Nco)
            query.Add(x => x.CreatorId == creatorId);
        if (request.managerId != null && user.Role == UserRole.Admin)
            query.Add(x => x.CreatorId == request.managerId);

        if (request.nccId != null)
            query.Add(x => x.NccId == request.nccId);

        if (request.packageProductId != null)
            query.Add(x => x.PackageProductId == request.packageProductId);

        if (request.remain != null)
            query.Add(x => x.Remain == request.remain);

        if (request.startDate != null)
            query.Add(x => x.StartDate == request.startDate);

        if (request.endDate != null)
            query.Add(x => x.EndDate == request.endDate);

        return query;
    }

    public async Task<ApiResponse> Invoices(int creatorId, GetInvoicesModel request)
    {
        var query = await QueryInvoice(creatorId, request);

        var invoices = await _invoiceRepository.FindIncludeAsync(query.ToArray(),
            request.OrderBy, "InvoiceDetails", request.Skip(), request.PageCount);

        return ApiResponse.Success(invoices.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = invoices.TotalCount,
            Page = request.Page
        });
    }

    private async Task<decimal> CreatePackageProduct(int creatorId, CreateInvoiceDetailModel model)
    {
        decimal price;
        var invoiceDetails = new List<InvoiceDetail>();
        var products = await _productService.Products();

        var packageById =
            await _packageProductService.GetPackageProductByIdAsync(model.packageProductInInvoice.PackageProductId);
        if (packageById.CreatorId != creatorId)
            throw new ApiException(ApiMessage.NotRole, ErrorCode.NOT_ROLE);

        var duration = packageById.Duration;

        ///B1: Xem lớn hơn bao nhiêu
        ///B2: tính trung bình mỗi một ngày sử dụng gói
        ///B3: Lấy giá tổng gói + giá của ngày chệnh lệch
        if (duration < model.duration)
        {
            var total = model.duration - duration;
            double averagedPrice = (double)(packageById.TotalAmount / packageById.Duration);
            price = packageById.TotalAmount + (int)(averagedPrice * total);
        }
        else if (duration > model.duration)
        {
            var total = duration - model.duration;
            double averagedPrice = (double)(packageById.TotalAmount / packageById.Duration);
            price = packageById.TotalAmount + (int)(averagedPrice * total);
        }
        else
        {
            price = packageById.TotalAmount;
        }


        ///Thêm các Product vào deatailInvoice
        foreach (var item in packageById.PackageProductDetails)
        {
            var productById = products.FirstOrDefault(x => x.Id == item.ProductId);
            if (productById == null) continue;
            var data = new InvoiceDetail
            {
                InvoiceId = model.invoiceId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = productById.Price,
                CreatorId = creatorId
            };
            invoiceDetails.Add(data);
        }

        await _invoiceDetailRepository.InsertAsync(invoiceDetails);
        await _invoiceDetailRepository.SaveChangeAsync();

        return price;
    }

    private async Task<decimal> CreateProduct(int creatorId, CreateInvoiceDetailModel model)
    {
        decimal price = 0;

        foreach (var item in model.productInInvoices)
        {
            var productById = await _productService.GetProductByIdAsync(item.ProductId);
            if (productById == null) continue;
               
            var data = new InvoiceDetail()
            {
                InvoiceId = model.invoiceId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price ?? productById.Price,
                CreatorId = creatorId
            };

            await _invoiceDetailRepository.InsertAsync(data);
            await _invoiceDetailRepository.SaveChangeAsync();

            price = (item.Price ?? productById.Price) * item.Quantity;
        }

        return price * model.duration;
    }

    private async Task<decimal> GetCreateInvoiceDetail(int creatorId, CreateInvoiceDetailModel model)
    {
        decimal totalAmount = 0;
        var invoiceById = await GetInvoiceByIdAsync(creatorId,model.invoiceId);
        if (invoiceById.CreatorId != creatorId)
            throw new ApiException(
                ApiMessage.NotRole, ErrorCode.NOT_ROLE);

        if (model.packageProductInInvoice != null)
        {
            totalAmount = await CreatePackageProduct(creatorId, model);
        }
        else if (model.productInInvoices != null && model.productInInvoices.Any())
        {
            totalAmount = await CreateProduct(creatorId, model);
        }

        return totalAmount;
    }

    private async Task<Invoice> GetCreateInvoice(int managerId,int ncId ,CreateInvoiceModel model)
    {
        var startDate = DateTime.Now;
        var endDate = startDate.AddDays(model.duration);

        var data = new Invoice
        {
            NccId = (int)model.nccId,
            PackageProductId = model.packageProductInInvoice?.PackageProductId,
            Duration = model.duration,
            Remain = model.duration,
            StartDate = startDate,
            EndDate = endDate,
            NcId = ncId,
            CreatorId = managerId
        };

        await _invoiceRepository.InsertAsync(data);
        await _invoiceRepository.SaveChangeAsync();

        return data;
    }


    private async Task CreateInvoiceAndDetail(int managerId,int ncId, CreateInvoiceModel request)
    {
        var invoice = await GetCreateInvoice(managerId, ncId, request);
        var inVoiceById = await GetInvoiceByIdAsync(managerId, invoice.Id);
        var dInvoice = new CreateInvoiceDetailModel
        {
            invoiceId = invoice.Id,
            duration = invoice.Duration,
            packageProductInInvoice = request.packageProductInInvoice,
            productInInvoices = request.productInInvoices,
        };

        var totalAmount = await GetCreateInvoiceDetail(managerId, dInvoice);

        inVoiceById.TotalAmount = totalAmount;


        _invoiceRepository.Update(inVoiceById);
        await _invoiceRepository.SaveChangeAsync();
    }


    public async Task<ApiResponse> Create(int managerId, CreateInvoiceModel request)
    {
        if (request.ncId is > 0)
        {
            var nccIds = await _nccService.GetNCCs();
            var ncIds = nccIds.Where(x => x.CreatorId == managerId
                                        && x.ManagerId == request.ncId).ToList();

            foreach (var item in ncIds)
            {
                request.nccId = item.Id;
                await CreateInvoiceAndDetail(managerId, item.ManagerId, request);
            }
        }
        else
        {
            var nccById = await _nccService.GetNccById((int)request.nccId);
            if (nccById.CreatorId != managerId)
                throw new ApiException(
                    ApiMessage.NotRole, ErrorCode.NOT_ROLE);

            await CreateInvoiceAndDetail(managerId, nccById.ManagerId, request);
        }

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> Delete(int invoiceId, int creatorId)
    {
        var invoicesById = await GetInvoiceByIdAsync(creatorId,invoiceId);
        if (invoicesById.CreatorId != creatorId)
            throw new ApiException(
                ApiMessage.NotRole, ErrorCode.NOT_ROLE);

        invoicesById.IsDeleted = true;
        invoicesById.TimeDelete = DateTime.Now;
        invoicesById.UpdateDate = DateTime.Now;

        var invoices = await GetInvoiceDetailsByIdAsync(invoiceId);

        if (invoices is { Count: > 0 })
        {
            var data = new List<InvoiceDetail>();

            Parallel.ForEach(invoices, item =>
            {
                item.IsDeleted = true;
                item.TimeDelete = DateTime.Now;
                item.UpdateDate = DateTime.Now;
                data.Add(item);
            });

            _invoiceDetailRepository.Update(data);
            await _invoiceDetailRepository.SaveChangeAsync();
        }

        _invoiceRepository.Update(invoicesById);
        await _invoiceRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }
}
