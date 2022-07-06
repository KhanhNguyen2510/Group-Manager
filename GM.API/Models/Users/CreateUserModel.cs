namespace GM.API.Models.Users;

public class CreateUserModel
{
    public string fullName { get; set; }

    [Required(ErrorMessage = "Nhập tên Email")]
    public string email { get; set; }

    [Required(ErrorMessage = "Nhập tên đăng nhập")]
    public string userName { get; set; }

    //[Required(ErrorMessage = "Nhập mật khẩu")]
    //public string password { get; set; }
    [MinLength(9, ErrorMessage = "Số điện thoại không hợp lệ")]
    [Required(ErrorMessage = "Nhập số điện thoại")]
    public string phoneNumber { get; set; }

    public UserRole userRole { get; set; }
}