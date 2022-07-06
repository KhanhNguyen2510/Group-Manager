using GM.API.Models.Events;

namespace GM.API.Areas.Admin.Controllers
{
    public class EventController : ApiBaseController
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{eventId}/user-play-events")]
        [SwaggerOperation(Summary = "Hiển thị danh sách người tham gia sự kiện")]
        public async Task<ApiResponse> GetUserPlayChallengersAsync(int eventId)
        {
            var gChallenge = await _eventService.GetUserPlayEventsAsync(CurrentUserId, eventId);
            return gChallenge;
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Hiển thị danh sách các sự kiện")]
        public async Task<ApiResponse> Events([FromQuery] GetEventsModel request)
        {
            var gEvent = await _eventService.Events(CurrentUserId, request);
            return gEvent;
        }

        [HttpGet("{eventId}")]
        [SwaggerOperation(Summary = "Hiển thị sự kiện thep mã")]
        public async Task<ApiResponse> EventById(int eventId)
        {
            var gEvent = await _eventService.EventById(CurrentUserId, eventId);
            return gEvent;
        }
    }
}
