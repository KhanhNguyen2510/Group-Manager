namespace GM.API.Models.Challenges;

public class CreateChallengeModel 
{
    [Required(ErrorMessage = "Nhập tên người dùng")]
    public string name { get; set; }
    public string content { get; set; }

    [Required(ErrorMessage = "Nhập ngày bắt đầu")]
    public DateTime startDate { get; set; }

    [Required(ErrorMessage = "Nhập ngày kết thúc")]
    public DateTime endDate { get; set; }
}
