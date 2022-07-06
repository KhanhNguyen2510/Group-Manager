namespace GM.API.Models.Auths;

public class AuthModel
{
    [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
    public string Password { get; set; }
}
