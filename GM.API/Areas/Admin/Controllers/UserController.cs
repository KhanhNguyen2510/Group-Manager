global using GM.API.Services;
global using Microsoft.AspNetCore.Mvc;
global using Swashbuckle.AspNetCore.Annotations;
global using GM.Data.Models;
using GM.API.Models.Users;
using GM.API.Middlewares;

namespace GM.API.Areas.Admin.Controllers;

public class UserController : ApiBaseController
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Hiển thị danh sách người dùng")]
    public async Task<ApiResponse> Users([FromQuery] GetUsersModel model)
    {
        var gUser = await _userService.Users(model);
        return gUser;
    }

    [HttpGet("{userId}")]
    [SwaggerOperation(Summary = "Xem tài khoản bằng mã")]
    public async Task<ApiResponse> UserById(int userId)
    {
        var gUser = await _userService.UserById(userId);
        return gUser;
    }
    [AllowAnonymous]
    [HttpPost]
    [SwaggerOperation(Summary = "Tạo tài khoản người dùng")]
    public async Task<ApiResponse> Create([FromBody] CreateUserModel model)
    {
        var gUser = await _userService.Create(CurrentUserId, model);
        return gUser;
    }

    [HttpPatch("{userId}")]
    [SwaggerOperation(Summary = "Cập nhật tài khoản")]
    public async Task<ApiResponse> Update(int userId, [FromBody] UpdateUserModel model)
    {
        var gUser = await _userService.Update(userId, model);
        return gUser;
    }

    [HttpPost("{userId}/up-role")]
    [SwaggerOperation(Summary = "Tạo tài khoản người dùng")]
    public async Task<ApiResponse> UpdateUserRole(int userId, UserRole userRole)
    {
        var gUser = await _userService.UpdateUserRole(userId, userRole);
        return gUser;
    }
    
    [HttpPatch("{userId}/refresh-password")]
    [SwaggerOperation(Summary = "Cập nhật mật khẩu với tài khoản mới")]
    public async Task<ApiResponse> Update(int userId, [FromBody ] UpdatePasswordModel model)
    {
        var gUser = await _userService.RefreshPassWord(userId,model );
        return gUser;
    }

    [HttpDelete("{userId}")]
    [SwaggerOperation(Summary = "Xoá tài khoản")]
    public async Task<ApiResponse> Delete(int userId)
    {
        var gUser = await _userService.Delete(userId);
        return gUser;
    }
}
