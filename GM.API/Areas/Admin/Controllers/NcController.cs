using GM.API.Models.Ncs;

namespace GM.API.Areas.Admin.Controllers;

public class NcController : ApiBaseController
{
    private readonly INcService _ncService;

    public NcController(INcService ncService)
    {
        _ncService = ncService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Hiển thị danh sách nhóm")]
    public async Task<ApiResponse> Ncs([FromQuery] GetNCsModel request)
    {
        var gNc = await _ncService.Ncs(CurrentUserId,request);
        return gNc;
    }

    [HttpGet("{ncId}")]
    [SwaggerOperation(Summary = "Hiển thị nhóm theo mã")]
    public async Task<ApiResponse> NcById(int ncId)
    {
        var gNc = await _ncService.NcById(ncId);
        return gNc;
    }

    [HttpPost("nco/{managerId}")]
    [SwaggerOperation(Summary = "Tạo NC")]
    public async Task<ApiResponse> Create(int managerId, [FromBody] CreateNcModel request)
    {
        var gNc = await _ncService.Create(managerId, CurrentUserId,  request);
        return gNc;
    }

    [HttpPatch("{ncId}")]
    [SwaggerOperation(Summary = "Cập nhật NC")]
    public async Task<ApiResponse> Update(int ncId, [FromBody] UpdateNcModel request)
    {
        var gNc = await _ncService.Update(ncId, request);
        return gNc;
    }

    [HttpDelete("{ncId}")]
    [SwaggerOperation(Summary = "Xóa một NC")]
    public async Task<ApiResponse> Delete(int ncId)
    {
        var gNc = await _ncService.Delete(ncId);
        return gNc;
    }
}
