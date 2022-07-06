namespace GM.API.Models.Events;

public class DeleteEventModel
{
    [Required(ErrorMessage = "Nhập thông tin người quàn lý")]
    public int ManagerId { get; set; }
}
