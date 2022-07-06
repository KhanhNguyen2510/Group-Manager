using GM.API.Middlewares;
using GM.Data.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Areas.Admin.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "admin"), Area("admin")]
    [Route("v{version:apiVersion}/[area]/[Controller]")]
    [Authorize(new[] { UserRole.Admin })]
    public class ApiBaseController : ControllerBase
    {
        protected int CurrentUserId => User.GetUserId();
    }
}
