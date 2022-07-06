using GM.API.Models.Nccs;

namespace GM.API.Areas.Admin.Controllers;

public class NccController : ApiBaseController
{
    private readonly INccService _nccService;
    public NccController(INccService ncService)
    {
        _nccService = ncService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Hiển thị danh sách Ncc")]
    public async Task<ApiResponse> Nccs([FromQuery] GetNccModel request)
    {
        var gNcc = await _nccService.Nccs(CurrentUserId,request);
        return gNcc;
    }

    [HttpGet("{nccId}")]
    [SwaggerOperation(Summary = "Hiển thị Ncc theo mã")]
    public async Task<ApiResponse> NccById(int nccId)
    {
        var gNcc = await _nccService.NccById(nccId, CurrentUserId);
        return gNcc;
    }
}
