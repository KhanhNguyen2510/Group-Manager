namespace GM.API.Models.Nccs;

public class CreateNccModel
{
    [Required(ErrorMessage = "Nhập tên thành viên")]
    public string name { get; set; }
    [Required(ErrorMessage = "Nhập ngày sinh")]
    public DateTime birthDay { get; set; }
    [MinLength(9, ErrorMessage = "Số điện thoại không hợp lệ")]
    [Required(ErrorMessage = "Nhập số điện thoại")]
    public string phoneNumber { get; set; }
    public string address { get; set; }
}
