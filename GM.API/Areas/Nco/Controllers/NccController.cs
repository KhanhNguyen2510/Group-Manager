using GM.API.Models.Nccs;

namespace GM.API.Areas.Nco.Controllers;

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
        var gNcc = await _nccService.Nccs(CurrentUserId, request);
        return gNcc;
    }

    [HttpGet("{nccId}")]
    [SwaggerOperation(Summary = "Hiển thị Ncc theo mã")]
    public async Task<ApiResponse> NccById(int nccId)
    {
        var gNcc = await _nccService.NccById( CurrentUserId,nccId);
        return gNcc;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Tạo Ncc")]
    public async Task<ApiResponse> Create(int managerId,[FromBody] CreateNccModel request)
    {
        var gNcc = await _nccService.Create(CurrentUserId, managerId,request);
        return gNcc;
    }

    [HttpPatch("{nccId}")]
    [SwaggerOperation(Summary = "Cập nhật Ncc")]
    public async Task<ApiResponse> Update(int nccId, [FromBody] UpdateNccModel request)
    {
        var gNcc = await _nccService.Update( CurrentUserId, nccId, request);
        return gNcc;
    }

    [HttpDelete("{nccId}")]
    [SwaggerOperation(Summary = "Xóa Ncc")]
    public async Task<ApiResponse> Delete(int nccId)
    {
        var gNcc = await _nccService.Delete(CurrentUserId,nccId);
        return gNcc;
    }
}
