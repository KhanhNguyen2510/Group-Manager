namespace GM.API.Models.Events;

public class CreateUserPlayEventModel
{
    public string note { get; set; }
    [Required(ErrorMessage = "Nhập người tham gia")]
    public int nccId { get; set; }
}
