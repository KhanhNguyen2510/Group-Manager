using System.Text.Json.Serialization;

namespace GM.API.Models.Invoices;

public class CreateInvoiceModel
{
    //[Required(ErrorMessage = "Nhập mã người mua")]
    public int? nccId { get; set; }
    [Required(ErrorMessage = "Nhập thời hạn")]
    public int duration { get; set; }
    public int? ncId { get; set; }

    public PackageProductInInvoice packageProductInInvoice { get; set; }
    public List<ProductInInvoices> productInInvoices { get; set; }
}
public class PackageProductInInvoice
{
    public int PackageProductId { get; set; }
    public decimal? Price { get; set; }
}
public class ProductInInvoices
{
    public int ProductId { get; set; }
    public int Quantity { get; set; } = 0;
    public decimal? Price { get; set; }
}
