namespace GM.API.Models.Invoices;

public class CreateInvoiceDetailModel
{
    [Required(ErrorMessage = "Nhập mã hóa đơn")]
    public int invoiceId { get; set; }
    [Required(ErrorMessage = "Nhập thời hạn sử dụng")]
    public int duration { get; set; }
    public PackageProductInInvoice packageProductInInvoice { get; set; }
    public List<ProductInInvoices> productInInvoices { get; set; }
}
