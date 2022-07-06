namespace GM.API.Models.Events;

public class DeleteUserPlayEventModel
{
    [Required(ErrorMessage = "Nhập mã người quản lý")]
    public int ManagerId { get; set; }
}
