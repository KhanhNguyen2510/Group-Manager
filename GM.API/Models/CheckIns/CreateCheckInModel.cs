namespace GM.API.Models.CheckIns;

public class CreateCheckInModel
{
    //[Required(ErrorMessage = "Nhập mã hóa đơn")]
    public int? invoiceId { get; set; }
    [Required(ErrorMessage = "Nhập thời gian điềm danh")]
    public Session session { get; set; }

    public int? ncId { get; set; }  
}
