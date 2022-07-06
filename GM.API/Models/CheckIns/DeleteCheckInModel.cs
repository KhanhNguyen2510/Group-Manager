namespace GM.API.Models.CheckIns;

public class  DeleteCheckInModel
{
    [Required (ErrorMessage = "Nhập lý do xóa")]
    public string note { get; set; }
}