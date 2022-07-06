using GM.API.Middlewares;
using GM.Data.Helpers;

namespace GM.API.Areas.Nco.Controllers;

[ApiController]
[ApiVersion("1")]
[ApiExplorerSettings(GroupName = "nco"), Area("nco")]
[Route("v{version:apiVersion}/[area]/[Controller]")]
[Authorize(new[] { UserRole.Nco })]
public class ApiBaseController : ControllerBase
{
    protected int CurrentUserId => User.GetUserId();
}