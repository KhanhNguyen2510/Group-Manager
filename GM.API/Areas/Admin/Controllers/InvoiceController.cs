using GM.API.Models.Invoices;

namespace GM.API.Areas.Admin.Controllers;

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
        var gInvoice = await _invoiceService.Invoices(CurrentUserId,request);
        return gInvoice;
    } 

    [HttpGet("{invoiceId}")]
    [SwaggerOperation(Summary = "Hiển thị hóa đơn theo mã hóa đơn")]
    public async Task<ApiResponse> GetInvoicesById(int invoiceId)
    {
        var gInvoice = await _invoiceService.InvoicesById(CurrentUserId,invoiceId);
        return gInvoice;
    }   
}