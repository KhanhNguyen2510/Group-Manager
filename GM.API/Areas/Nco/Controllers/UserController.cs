using GM.API.Models.Users;

namespace GM.API.Areas.Nco.Controllers;

public class UserController : ApiBaseController
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPatch("refresh-password")]
    [SwaggerOperation(Summary = "Cập nhật mật khẩu với tài khoản mới")]
    public async Task<ApiResponse> RefreshPassWord([FromBody] UpdatePasswordModel model)
    {
        var gUser = await _userService.RefreshPassWord(CurrentUserId, model);
        return gUser;
    }
}