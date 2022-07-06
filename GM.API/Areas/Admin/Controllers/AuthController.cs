using GM.API.Middlewares;
using GM.API.Models.Auths;

namespace GM.API.Areas.Admin.Controllers;

public class AuthController : ApiBaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("log-in")]
    public async Task<ApiResponse> Auth([FromBody] AuthModel authModel)
    {
        return await _authService.Auth(authModel, UserRole.Admin);
    }
}