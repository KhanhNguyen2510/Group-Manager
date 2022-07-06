namespace GM.API.Models.Invoices;

public class UpdateInvoiceModel
{
    public Status? status { get; set; }
    [Required(ErrorMessage = "Nhập mã người quản lý")]
    public int managerId { get; set; }
}
