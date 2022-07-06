using System.ComponentModel.DataAnnotations;

namespace GM.API.Models.Users;

public class UpdatePasswordModel
{
    [Data.Validations.Required(ErrorMessage = "Nhập mật khẩu")]
    public string newPass { get; set; }

    [Data.Validations.Required(ErrorMessage = "Nhập lại mật khẩu")]
    public string confirmPass { get; set; }
}
