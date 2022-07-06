using GM.API.Models.Events;
using GM.Data.EFs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GM.API.Services;

public interface IEventService
{
    Task<ApiResponse> Create(int managerId, CreateEventModel request);
    Task<ApiResponse> Update(int managerId, int eventId, UpdateEventModel request);
    Task<ApiResponse> Delete(int managerId, int eventId);
    Task<ApiResponse> EventById(int managerId, int eventId);
    Task<ApiResponse> Events(int managerId, GetEventsModel request);

    Task<ApiResponse> CreateUserEvent(int managerId, int eventId, int nccId,
        CreateUserPlayEventModel request);

    Task<ApiResponse> UpdatePlayEvent(int managerId, int eventId, int nccId,
        UpdateUserPlayEventModel request);

    Task<ApiResponse> DeletePlayEvent(int managerId, int eventId, int nccId);
    Task<ApiResponse> UserPlayEventById(int managerId, int eventId, int nccId);

    Task<ApiResponse> UserPlayEvents(int managerId,
        GetUserPlayEventsModel request);

    Task<ApiResponse> GetUserPlayEventsAsync(int managerId, int eventId);
}
public class EventService : IEventService
{
    private readonly IUserService _userService;
    private readonly IEventRepository _eventRepository;
    private readonly IUserPlayEventRepository _userPlayEventRepository;
    private readonly INccService _nccService;
    private readonly GMDbContext _context;
    public EventService(IUserService userService,
        IEventRepository eventRepository,
        IUserPlayEventRepository userPlayEventRepository,
        INccService nccService,     
        GMDbContext context
        )
    {
        _context = context;
        _userService = userService;
        _eventRepository = eventRepository;
        _userPlayEventRepository = userPlayEventRepository;
        _nccService = nccService;
    }
    
    public async Task<ApiResponse> Create(int managerId, CreateEventModel request)
    {
        bool cStartAndEndDate = DateTime.Now.Date <= request.startDate.Date
                         && request.startDate.Date <= request.endDate.Date;

        if (!cStartAndEndDate)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);

        var data = new Event
        {
            Name = request.name,
            Content = request.content,
            StartDate = request.startDate,
            EndDate = request.endDate,
            ManagerId = managerId,
            CreatorId = managerId
        };

        await _eventRepository.InsertAsync(data);
        await _eventRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<Event> GetEventById(int eventId)
    {
        var eventById = await _eventRepository.FindOneAsync(new Expression<Func<Event, bool>>[]
        {
            c => c.IsDeleted == false
                 && c.Id == eventId
        }, "UserPlayEvents");

        if (eventById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return eventById;
    }

    private async Task<List<UserPlayEvent>> GetUserPlayEvents(int eventId)
    {
        var userEvents = await _userPlayEventRepository.FindAsync(
             new Expression<Func<UserPlayEvent, bool>>[]
             {
                u => u.IsDeleted == false
                && u.EventId == eventId
             }, string.Empty, string.Empty);
        if (userEvents == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return userEvents;
    }



    public async Task<ApiResponse> GetUserPlayEventsAsync(int managerId, int eventId)
    {
        var userEvents = await GetUserPlayEvents(eventId);
        var nccs = await _nccService.GetNCCs();
        var userById = await _userService.GetUserByIdAsync(managerId);
        if (userById.Role == UserRole.Nco)
        {
            userEvents = userEvents.Where(x => x.CreatorId == managerId).ToList();
            nccs = nccs.Where(x => x.CreatorId == managerId).ToList();
        }

        var nccIds = userEvents.Select(x => x.NccId).Distinct();
        var userPlayChallengers = nccs.Where(x => nccIds.Contains(x.Id)).ToList();
        return ApiResponse.Success(userPlayChallengers);
    }


    public async Task<ApiResponse> Update(int managerId, int eventId, UpdateEventModel request)
    {
        var eventById = await GetEventById(eventId, managerId);

        if (request.startDate != null)
        {
            var gEndDate = request.endDate ?? eventById.EndDate;
            bool cStartDate = DateTime.Now.Date <= request.startDate.Value.Date &&
                              request.startDate.Value.Date <= gEndDate.Date;

            if (!cStartDate)
                throw new ApiException(
                    ApiMessage.InvalidStartDateOrEndDate,
                    ErrorCode.NOT_FOUND);

            eventById.StartDate = (DateTime)request.startDate;
        }

        if (request.endDate != null)
        {
            var gStarDate = request.startDate ?? eventById.StartDate;

            bool cEndDate = gStarDate.Date <= request.endDate.Value.Date;

            if (!cEndDate)
                throw new ApiException(
                    ApiMessage.InvalidStartDateOrEndDate,
                    ErrorCode.NOT_FOUND);

            eventById.EndDate = (DateTime)request.endDate;
        }

        eventById.Name = request.name ?? eventById.Name;
        eventById.Content = request.content ?? eventById.Content;
        eventById.UpdateDate = DateTime.Now;

        _eventRepository.Update(eventById);
        await _eventRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<List<UserPlayEvent>> GetUserEventById(int eventId)
    {
        var userEventsById = await _userPlayEventRepository.FindAsync(
            new Expression<Func<UserPlayEvent, bool>>[]
            {
                u => u.IsDeleted == false
                     && u.EventId == eventId
            }, string.Empty, string.Empty);

        if (userEventsById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return userEventsById;
    }

    public async Task<ApiResponse> Delete(int managerId, int eventId)
    {
        await DeleteUserPlayEvents(eventId);
        await DeleteEvent(eventId, managerId);
        return ApiResponse.Success();
    }

    private async Task DeleteUserPlayEvents(int eventId)
    {
        var userEvents = await GetUserEventById(eventId);

        if (userEvents is { Count: > 0 })
        {
            var data = new List<UserPlayEvent>();
            Parallel.ForEach(userEvents, item =>
            {
                item.IsDeleted = true;
                item.TimeDelete = DateTime.Now;
                item.UpdateDate = DateTime.Now;
                data.Add(item);
            });
            _userPlayEventRepository.Update(data);
            await _eventRepository.SaveChangeAsync();
        }
    }

    private async Task DeleteEvent(int eventId, int managerId)
    {
        var eventById = await GetEventById(eventId, managerId);

        eventById.IsDeleted = true;
        eventById.TimeDelete = DateTime.Now;
        eventById.UpdateDate = DateTime.Now;

        _eventRepository.Update(eventById);
        await _eventRepository.SaveChangeAsync();
    }

    private async Task<Event> GetEventById(int eventId, int managerId)
    {
        var userIds = await _userService.GetUserRoleAdmin();

        var eventById = await _eventRepository.FindOneAsync(new Expression<Func<Event, bool>>[]
        {
            c => c.IsDeleted == false
                && userIds.Contains((int)c.CreatorId) || c.CreatorId == managerId
                && c.Id == eventId
        }, "UserPlayEvents");

        if (eventById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return eventById;
    }

    public async Task<ApiResponse> EventById(int managerId,int eventId)
    {
        var userEventById = await GetEventById(eventId);
        var user = await _userService.GetUserByIdAsync(managerId);
        if (user.Role == UserRole.Nco)
        {
            if (userEventById.ManagerId != managerId)
                throw new ApiException(
                    ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        }
        return ApiResponse.Success(userEventById);
    }

    private async Task<List<Expression<Func<Event, bool>>>> QueryEvent(int managerId,GetEventsModel request)
    {
        var query = new List<Expression<Func<Event, bool>>>() { x => x.IsDeleted == false };
        var user = await _userService.GetUserByIdAsync(managerId);

        if (user.Role == UserRole.Nco)
            query.Add(x => x.CreatorId == managerId);
        if (request.managerId != null)
            query.Add(x => x.ManagerId == request.managerId);

        if (!string.IsNullOrEmpty(request.keyWord))
            query.Add(x => x.Name.Contains(request.keyWord)
                           || x.Content.Contains(request.keyWord));

        if (request.startDate != null)
            query.Add(x => x.StartDate.Date == request.startDate.Value.Date);

        if (request.endDate != null)
            query.Add(x => x.EndDate.Date == request.endDate.Value.Date);

        return query;
    }

    public async Task<ApiResponse> Events(int managerId,GetEventsModel request)
    {
        var query = await QueryEvent(managerId, request);

        var events = await _eventRepository.FindIncludeAsync(query.ToArray(),
            request.OrderBy, "UserPlayEvents", request.Skip(), request.PageCount);

        return ApiResponse.Success(events.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = events.TotalCount,
            Page = request.Page
        });
    }

    // trạng thái chờ/ ngày bắt đầu diển ra / (chưa hoàn thành bỏ ) hoàn thành
    // admin tạo challage
    public async Task<ApiResponse> CreateUserEvent(int managerId, int eventId, int nccId,
        CreateUserPlayEventModel request)
    {
        Complete complete;
        var eventById = await GetEventById(eventId, managerId);

        await _nccService.GetNccById(nccId);

        var userEventById = await GetUserEventByNccAndId(eventId, nccId);

        if (userEventById != null && userEventById.Complete != Complete.Done)
        {
            throw new ApiException(
                ApiMessage.EventNotDone, ErrorCode.NOT_FOUND);
        }

        if (DateTime.Now.Date < eventById.StartDate.Date)
        {
            complete = Complete.Wait;
        }
        else if (eventById.StartDate.Date <= DateTime.Now.Date
                 && DateTime.Now.Date <= eventById.EndDate)
        {
            complete = Complete.InProcess;
        }
        else //if(EventrById.EndDate.Date <= DateTime.Now.Date)
        {
            throw new ApiException(
                ApiMessage.InvalidEndDate, ErrorCode.NOT_FOUND);
        }

        var data = new UserPlayEvent
        {
            NccId = nccId,
            EventId = eventId,
            Note = request.note,
            Complete = complete,
            CreatorId = managerId
        };

        await _userPlayEventRepository.InsertAsync(data);
        await _userPlayEventRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<List<UserPlayEvent>> GetUserEventsByNccAndId(int managerId, int eventId, int nccId)
    {
        var userIds = await _userService.GetUserRoleAdmin();
        return await _userPlayEventRepository.FindAsync(new Expression<Func<UserPlayEvent, bool>>[]
        {
            c => c.IsDeleted == false
                && userIds.Contains((int)c.CreatorId) || c.CreatorId == managerId
                && c.EventId == eventId
                && c.NccId == nccId
        }, string.Empty, string.Empty);
    }

    private async Task<UserPlayEvent> GetUserEventByNccAndId(int eventId, int nccId)
    {
        return await _context.UserPlayEvents.LastOrDefaultAsync(
            x => x.IsDeleted == false
                 && x.EventId == eventId
                 && x.NccId == nccId);
    }

    public async Task<ApiResponse> UpdatePlayEvent(int managerId, int eventId, int nccId,
        UpdateUserPlayEventModel request)
    {
        await GetEventById(eventId, managerId);
        await _nccService.GetNccById(nccId);

        var userEventById = await GetUserEventByNccAndId(eventId, nccId);

        if (userEventById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);

        userEventById.Complete = request.complete ?? userEventById.Complete;
        userEventById.Note = request.note ?? userEventById.Note;
        userEventById.UpdateDate = DateTime.Now;

        _userPlayEventRepository.Update(userEventById);
        await _userPlayEventRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> DeletePlayEvent(int managerId, int eventId, int nccId)
    {
        await GetEventById(eventId, managerId);
        await _nccService.GetNccById(nccId);

        var userEventById = await GetUserEventByNccAndId(eventId, nccId);
        if (userEventById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);

        userEventById.IsDeleted = true;
        userEventById.TimeDelete = DateTime.Now;
        userEventById.UpdateDate = DateTime.Now;

        _userPlayEventRepository.Update(userEventById);
        await _userPlayEventRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> UserPlayEventById(int managerId, int eventId, int nccId)
    {
        var gUserPlayEventById = await GetUserEventsByNccAndId(managerId, eventId, nccId);

        if (gUserPlayEventById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);

        return ApiResponse.Success(gUserPlayEventById);
    }

    private async Task<List<Expression<Func<UserPlayEvent, bool>>>> QueryUserPlayEvent(int managerId,
        GetUserPlayEventsModel request)
    {
        var query = new List<Expression<Func<UserPlayEvent, bool>>>() { x => x.IsDeleted == false };

        var user = await _userService.GetUserByIdAsync(managerId);

        if (user.Role == UserRole.Nco)
            query.Add(x => x.CreatorId == managerId);
        if (request.managerId != null && user.Role == UserRole.Admin)
            query.Add(x => x.CreatorId == managerId);

        if (request.nccId != null)
            query.Add(x => x.NccId == request.nccId);

        if (request.complete != null)
            query.Add(x => x.Complete == request.complete);

        return query;
    }

    public async Task<ApiResponse> UserPlayEvents(int managerId,
        GetUserPlayEventsModel request)
    {
        var query = await QueryUserPlayEvent(managerId, request);

        var userPlayEvents = await _userPlayEventRepository.FindAsync(query.ToArray(),
            request.OrderBy, request.Skip(), request.PageCount);

        return ApiResponse.Success(userPlayEvents.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = userPlayEvents.TotalCount,
            Page = request.Page
        });
    }
}
