using GM.API.Models.Invoices;

namespace GM.API.Areas.Nco.Controllers;

public class InvoiceController : ApiBaseController
{
    private readonly IInvoiceService _invoiceService;
    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Hiển thị danh sách hóa đơn")]
    public async Task<ApiResponse> GetInvoices([FromQuery]GetInvoicesModel request)
    {
        var gInvoice = await _invoiceService.Invoices((int)CurrentUserId,request);
        return gInvoice;
    } 

    [HttpGet("{invoiceId}")]
    [SwaggerOperation(Summary = "Hiển thị hóa đơn theo mã hóa đơn")]
    public async Task<ApiResponse> GetInvoicesById(int invoiceId)
    {
        var gInvoice = await _invoiceService.InvoicesById((int)CurrentUserId,invoiceId);
        return gInvoice;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm hóa đơn")]
    public async Task<ApiResponse> Create([FromBody]CreateInvoiceModel request)
    {
        var gInvoice = await _invoiceService.Create((int)CurrentUserId, request);
        return gInvoice;
    } 
    
    [HttpDelete("{invoiceId}")]
    [SwaggerOperation(Summary = "Xóa hóa đơn")]
    public async Task<ApiResponse> Delete(int invoiceId)
    {
        var gInvoice = await _invoiceService.Delete(invoiceId,(int)CurrentUserId);
        return gInvoice;
    }
}