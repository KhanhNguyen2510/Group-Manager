namespace GM.API.Models.Events;

public class CreateEventModel
{
    [Required(ErrorMessage = "Nhập tên sự kiện")]
    public string name { get; set; }
    public string content { get; set; }
    [Required(ErrorMessage = "Nhập ngày bắt đầu")]
    public DateTime startDate { get; set; }
    [Required(ErrorMessage = "Nhập ngày kết thúc")]
    public DateTime endDate { get; set; }
}
