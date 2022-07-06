using GM.API.Models.CheckIns;

namespace GM.API.Areas.Nco.Controllers;

public class CheckInController : ApiBaseController
{
    private readonly ICheckInService _checkInService;
    public CheckInController(ICheckInService checkInService)
    {
        _checkInService = checkInService;
    }


    [HttpGet]
    [SwaggerOperation(Summary = "Hiển thị danh sách thông tin CheckIn")]
    public async Task<ApiResponse> CheckIns([FromQuery] GetCheckInsModel request)
    {
        var gCheckIn = await _checkInService.CheckIns(CurrentUserId, request);
        return gCheckIn;
    }
    [HttpGet("{checkInId}")]
    [SwaggerOperation(Summary = "Hiển thị thông tin CheckIn theo mả")]
    public async Task<ApiResponse> CheckIns(int checkInId)
    {
        var gCheckIn = await _checkInService.GetCheckInById(CurrentUserId, checkInId);
        return gCheckIn;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Tạo CheckIn")]
    public async Task<ApiResponse> Create([FromBody] CreateCheckInModel request)
    {
        var gCheckIn = await _checkInService.Create((int)CurrentUserId, request);
        return gCheckIn;
    }

    [HttpPatch("{checkInId}")]
    [SwaggerOperation(Summary = "Cập nhật CheckIn")]
    public async Task<ApiResponse> Update(int checkInId, [FromBody] UpdateCheckInModel request)
    {
        var gCheckIn = await _checkInService.Update(CurrentUserId,checkInId, request);
        return gCheckIn;
    }

    [HttpDelete("{checkInId}")]
    [SwaggerOperation(Summary = "Xóa CheckIn")]
    public async Task<ApiResponse> Delete(int checkInId,DeleteCheckInModel model)
    {
        var gCheckIn = await _checkInService.Delete(CurrentUserId,checkInId,model);
        return gCheckIn;
    }

}
