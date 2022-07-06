using GM.API.Models.CheckIns;

namespace GM.API.Areas.Admin.Controllers
{
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
    }
}
