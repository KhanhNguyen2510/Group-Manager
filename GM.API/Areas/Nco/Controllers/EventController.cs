using GM.API.Models.Events;

namespace GM.API.Areas.Nco.Controllers;

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
        var gEvent = await _eventService.Events( CurrentUserId,request);
        return gEvent;
    }

    [HttpGet("{eventId}")]
    [SwaggerOperation(Summary = "Hiển thị sự kiện thep mã")]
    public async Task<ApiResponse> EventById(int eventId)
    {
        var gEvent = await _eventService.EventById(CurrentUserId,eventId);
        return gEvent;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm sự kiện")]
    public async Task<ApiResponse> Create([FromBody] CreateEventModel request)
    {
        var gEvent = await _eventService.Create((int)CurrentUserId, request);
        return gEvent;
    }

    [HttpPatch("{eventId}")]
    [SwaggerOperation(Summary = "Cập nhật sự kiện")]
    public async Task<ApiResponse> Update(int eventId, [FromBody] UpdateEventModel request)
    {
        var gEvent = await _eventService.Update((int)CurrentUserId, eventId, request);
        return gEvent;
    }

    [HttpDelete("{eventId}")]
    [SwaggerOperation(Summary = "Xóa sự kiện")]
    public async Task<ApiResponse> Delete(int eventId)
    {
        var gEvent = await _eventService.Delete((int)CurrentUserId,eventId);
        return gEvent;
    }


    [HttpGet("{eventId}/users")]
    [SwaggerOperation(Summary = "Hiển thị danh sách người tham gia sự kiện")]
    public async Task<ApiResponse> UserPlayEvents(int eventId, [FromQuery] GetUserPlayEventsModel request)
    {
        var gEvent = await _eventService.UserPlayEvents((int)CurrentUserId, request);
        return gEvent;
    }

    [HttpPost("{eventId}/users")]
    [SwaggerOperation(Summary = "Tạo người chơi tham gia sự kiện")]
    public async Task<ApiResponse> CreatePlayEvent(int eventId,int nccId, [FromBody] CreateUserPlayEventModel request)
    {
        var gEvent = await _eventService.CreateUserEvent((int)CurrentUserId,eventId,nccId,  request);
        return gEvent;
    }

    [HttpPatch("{eventId}/users/{userId}")]
    [SwaggerOperation(Summary = "Cập nhật người chơi tham gia sự kiện")]
    public async Task<ApiResponse> UpdatePlayEvent(int eventId, int nccId, [FromBody] UpdateUserPlayEventModel request)
    {
        var gEvent = await _eventService.UpdatePlayEvent((int)CurrentUserId,eventId, nccId,  request);
        return gEvent;
    }

    [HttpDelete("{eventId}/users/{userId}")]
    [SwaggerOperation(Summary = "Xóa một người chơi tham gia sự kiện")]
    public async Task<ApiResponse> DeletePlayEvent(int eventId, int userId)
    {
        var gEvent = await _eventService.DeletePlayEvent((int)CurrentUserId,eventId, userId);
        return gEvent;
    }
}
