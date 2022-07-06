using GM.API.Models.Challenges;
using GM.Data.EFs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GM.API.Services;

public interface IChallengeService
{
    Task<ApiResponse> Create(int managerId, CreateChallengeModel request);
    Task<ApiResponse> Update(int managerId, int challengeId, UpdateChallengeModel request);
    Task<ApiResponse> Delete(int managerId, int challengerId);
    Task<ApiResponse> ChallengerById(int managerId,int challengerId);
    Task<ApiResponse> Challenges(int managerId, GetChallengesModel request);

    Task<ApiResponse> CreateUserChallenge(int managerId, int challengerId, int nccId,
        CreateUserPlayChallegeModel request);

    Task<ApiResponse> UpdatePlayChallenge(int managerId, int challengerId, int nccId,
        UpdateUserPlayChallengeModel request);

    Task<ApiResponse> DeletePlayChallenge(int managerId, int challengerId, int nccId);
    Task<ApiResponse> UserPlayChallengerById(int managerId, int challengerId, int nccId);

    Task<ApiResponse> UserPlayChallenges(int managerId,
        GetUserPlayChallengesModel request);

    Task<ApiResponse> GetUserPlayChallengersAsync(int managerId, int challengerId);
}

public class ChallengeService : IChallengeService
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly INccRepository _nccRepository;
    private readonly IUserService _userService;
    private readonly IUserPlayChallengeRepository _userPlayChallengeRepository;
    private readonly INccService _nccService;
    private readonly GMDbContext _context;

    public ChallengeService(
        IChallengeRepository challengeRepository,
        IUserService userService,
        IUserPlayChallengeRepository userPlayChallengeRepository,
        INccService nccService,
        INccRepository nccRepository,
        GMDbContext context
    )
    {
        _nccRepository = nccRepository;
        _context = context;
        _nccService = nccService;
        _challengeRepository = challengeRepository;
        _userService = userService;
        _userPlayChallengeRepository = userPlayChallengeRepository;
    }

    public async Task<ApiResponse> Create(int managerId, CreateChallengeModel request)
    {
        bool cStartAndEndDate = DateTime.Now.Date <= request.startDate.Date
                                && request.startDate.Date <= request.endDate.Date;

        if (!cStartAndEndDate)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);

        var data = new Challenge
        {
            Name = request.name,
            Content = request.content,
            StartDate = request.startDate,
            EndDate = request.endDate,
            ManagerId = managerId,
            CreatorId = managerId
        };

        await _challengeRepository.InsertAsync(data);
        await _challengeRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<Challenge> GetChallengeById(int challengeId)
    {
        var challengeById = await _challengeRepository.FindOneAsync(new Expression<Func<Challenge, bool>>[]
        {
            c => c.IsDeleted == false
                 && c.Id == challengeId
        }, "UserPlayChallenges");

        if (challengeById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return challengeById;
    }

    private async Task<List<UserPlayChallenge>> GetUserPlayChallenges(int challengerId)
    {
        var userChallengers = await _userPlayChallengeRepository.FindAsync(
             new Expression<Func<UserPlayChallenge, bool>>[]
             {
                u => u.IsDeleted == false
                && u.ChallengerId == challengerId
             }, string.Empty, string.Empty);
        if (userChallengers == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return userChallengers;
    }



    public async Task<ApiResponse> GetUserPlayChallengersAsync(int managerId,int challengerId)
    {
        var userChallengers = await GetUserPlayChallenges(challengerId);
        var nccs = await _nccService.GetNCCs();
        var userById = await _userService.GetUserByIdAsync(managerId);
        if (userById.Role == UserRole.Nco)
        {
            userChallengers = userChallengers.Where(x => x.CreatorId == managerId).ToList();
            nccs = nccs.Where(x => x.CreatorId == managerId).ToList();
        }

        var nccIds = userChallengers.Select(x => x.NccId).Distinct();
        var userPlayChallengers = nccs.Where(x => nccIds.Contains(x.Id)).ToList();
        return ApiResponse.Success(userPlayChallengers);
    }

    public async Task<ApiResponse> Update(int managerId, int challengeId, UpdateChallengeModel request)
    {
        var challengerById = await GetChallengerById(challengeId, managerId);

        if (request.startDate != null)
        {
            var gEndDate = request.endDate ?? challengerById.EndDate;
            bool cStartDate = DateTime.Now.Date <= request.startDate.Value.Date &&
                              request.startDate.Value.Date <= gEndDate.Date;

            if (!cStartDate)
                throw new ApiException(
                    ApiMessage.InvalidStartDateOrEndDate,
                    ErrorCode.NOT_FOUND);

            challengerById.StartDate = (DateTime)request.startDate;
        }

        if (request.endDate != null)
        {
            var gStarDate = request.startDate ?? challengerById.StartDate;

            bool cEndDate = gStarDate.Date <= request.endDate.Value.Date;

            if (!cEndDate)
                throw new ApiException(
                    ApiMessage.InvalidStartDateOrEndDate,
                    ErrorCode.NOT_FOUND);

            challengerById.EndDate = (DateTime)request.endDate;
        }

        challengerById.Name = request.name ?? challengerById.Name;
        challengerById.Content = request.content ?? challengerById.Content;
        challengerById.UpdateDate = DateTime.Now;

        _challengeRepository.Update(challengerById);
        await _challengeRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<List<UserPlayChallenge>> GetUserChallengerById(int challengerId)
    {
        var userChallengersById = await _userPlayChallengeRepository.FindAsync(
            new Expression<Func<UserPlayChallenge, bool>>[]
            {
                u => u.IsDeleted == false
                     && u.ChallengerId == challengerId
            }, string.Empty, string.Empty);

        if (userChallengersById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return userChallengersById;
    }

    public async Task<ApiResponse> Delete(int managerId, int challengerId)
    {
        await DeleteUserPlayChallengers(challengerId);
        await DeleteChallenger(challengerId, managerId);
        return ApiResponse.Success();
    }

    private async Task DeleteUserPlayChallengers(int challengerId)
    {
        var userChallengers = await GetUserChallengerById(challengerId);

        if (userChallengers is { Count: > 0 })
        {
            var data = new List<UserPlayChallenge>();
            Parallel.ForEach(userChallengers, item =>
            {
                item.IsDeleted = true;
                item.TimeDelete = DateTime.Now;
                item.UpdateDate = DateTime.Now;
                data.Add(item);
            });
            _userPlayChallengeRepository.Update(data);
            await _challengeRepository.SaveChangeAsync();
        }
    }

    private async Task DeleteChallenger(int challengerId, int managerId)
    {
        var challengerById = await GetChallengerById(challengerId, managerId);

        challengerById.IsDeleted = true;
        challengerById.TimeDelete = DateTime.Now;
        challengerById.UpdateDate = DateTime.Now;

        _challengeRepository.Update(challengerById);
        await _challengeRepository.SaveChangeAsync();
    }

    private async Task<Challenge> GetChallengerById(int challengeId, int managerId)
    {
        var userIds = await _userService.GetUserRoleAdmin();
        var dd = userIds.ToList();

        var challengerById = await _challengeRepository.FindOneAsync(new Expression<Func<Challenge, bool>>[]
        {
            c => c.IsDeleted == false
                && dd.Contains((int)c.CreatorId) || c.CreatorId == managerId
                && c.Id == challengeId
        }, "UserPlayChallenges");

        if (challengerById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return challengerById;
    }

    public async Task<ApiResponse> ChallengerById(int managerId,int challengerId)
    {
        var userChallengerById = await GetChallengeById(challengerId);
        var user = await _userService.GetUserByIdAsync(managerId);
        if (user.Role == UserRole.Nco)
        {
            if (userChallengerById.ManagerId != managerId)
                throw new ApiException(
                    ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        }

        return ApiResponse.Success(userChallengerById);
    }

    private async Task<List<Expression<Func<Challenge, bool>>>> QueryChallenger(int managerId,GetChallengesModel request)
    {
        var query = new List<Expression<Func<Challenge, bool>>>() { x => x.IsDeleted == false };
        var user = await _userService.GetUserByIdAsync(managerId);
        if (user.Role == UserRole.Nco)
            query.Add(x => x.ManagerId == managerId);
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

    public async Task<ApiResponse> Challenges(int managerId,GetChallengesModel request)
    {
        var query = await QueryChallenger(managerId,request);

        var challenges = await _challengeRepository.FindIncludeAsync(query.ToArray(),
            request.OrderBy, "UserPlayChallenges", request.Skip(), request.PageCount);

        return ApiResponse.Success(challenges.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = challenges.TotalCount,
            Page = request.Page
        });
    }

    // trạng thái chờ/ ngày bắt đầu diển ra / (chưa hoàn thành bỏ ) hoàn thành
    // admin tạo challage
    public async Task<ApiResponse> CreateUserChallenge(int managerId, int challengerId, int nccId,
        CreateUserPlayChallegeModel request)
    {
        Complete complete;
        var challengerById = await GetChallengerById(challengerId, managerId);

        await _nccService.GetNccById(nccId);

        var userChallengerById = await GetUserChallengerByNccAndId(challengerId, nccId);

        if (userChallengerById != null && userChallengerById.Complete != Complete.Done)
        {
            throw new ApiException(
                ApiMessage.ChallengerNotDone, ErrorCode.NOT_FOUND);
        }

        if (DateTime.Now.Date < challengerById.StartDate.Date)
        {
            complete = Complete.Wait;
        }
        else if (challengerById.StartDate.Date <= DateTime.Now.Date
                 && DateTime.Now.Date <= challengerById.EndDate)
        {
            complete = Complete.InProcess;
        }
        else //if(challengerById.EndDate.Date <= DateTime.Now.Date)
        {
            throw new ApiException(
                ApiMessage.InvalidEndDate, ErrorCode.NOT_FOUND);
        }

        var data = new UserPlayChallenge
        {
            NccId = nccId,
            ChallengerId = challengerId,
            Note = request.note,
            Complete = complete,
            CreatorId = managerId
        };

        await _userPlayChallengeRepository.InsertAsync(data);
        await _userPlayChallengeRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<List<UserPlayChallenge>> GetUserChallengersByNccAndId(int managerId, int challengerId, int nccId)
    {
        var userIds = await _userService.GetUserRoleAdmin();
        return await _userPlayChallengeRepository.FindAsync(new Expression<Func<UserPlayChallenge, bool>>[]
        {
            c => c.IsDeleted == false
                && userIds.Contains((int)c.CreatorId) || c.CreatorId == managerId
                && c.ChallengerId == challengerId
                && c.NccId == nccId
        }, string.Empty, string.Empty);
    }

    private async Task<UserPlayChallenge> GetUserChallengerByNccAndId(int challengerId, int nccId)
    {
        return await _context.UserPlayChallenges.Where(
            x => x.IsDeleted == false
                 && x.ChallengerId == challengerId
                 && x.NccId == nccId).OrderByDescending(x=>x.CreateDate).FirstOrDefaultAsync();
    }

    public async Task<ApiResponse> UpdatePlayChallenge(int managerId, int challengerId, int nccId,
        UpdateUserPlayChallengeModel request)
    {
        await GetChallengerById(challengerId, managerId);
        await _nccService.GetNccById(nccId);

        var userChallengerById = await GetUserChallengerByNccAndId(challengerId, nccId);

        if (userChallengerById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);

        userChallengerById.Complete = request.Complete ?? userChallengerById.Complete;
        userChallengerById.Note = request.note ?? userChallengerById.Note;
        userChallengerById.UpdateDate = DateTime.Now;

        _userPlayChallengeRepository.Update(userChallengerById);
        await _userPlayChallengeRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> DeletePlayChallenge(int managerId, int challengerId, int nccId)
    {
        await GetChallengerById(challengerId, managerId);
        await _nccService.GetNccById(nccId);

        var userChallengerById = await GetUserChallengerByNccAndId(challengerId, nccId);
        if (userChallengerById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);

        userChallengerById.IsDeleted = true;
        userChallengerById.TimeDelete = DateTime.Now;
        userChallengerById.UpdateDate = DateTime.Now;

        _userPlayChallengeRepository.Update(userChallengerById);
        await _userPlayChallengeRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> UserPlayChallengerById(int managerId, int challengerId, int nccId)
    {
        var gUserPlayChallengeById = await GetUserChallengersByNccAndId(managerId, challengerId, nccId);

        if (gUserPlayChallengeById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);

        return ApiResponse.Success(gUserPlayChallengeById);
    }

    private async Task<List<Expression<Func<UserPlayChallenge, bool>>>> QueryUserPlayChallenge(int managerId,
        GetUserPlayChallengesModel request)
    {
        var query = new List<Expression<Func<UserPlayChallenge, bool>>>() { x => x.IsDeleted == false };

        var user = await _userService.GetUserByIdAsync(managerId);

        if (user.Role == UserRole.Nco)
            query.Add(x => x.CreatorId == managerId);
        if (request.managerId != null)
            query.Add(x => x.CreatorId == managerId);

        if (request.nccId != null)
            query.Add(x => x.NccId == request.nccId);

        if (request.complete != null)
            query.Add(x => x.Complete == request.complete);

        return query;
    }

    public async Task<ApiResponse> UserPlayChallenges(int managerId,
        GetUserPlayChallengesModel request)
    {
        var query = await QueryUserPlayChallenge(managerId, request);

        var userPlayChallenges = await _userPlayChallengeRepository.FindAsync(query.ToArray(),
            request.OrderBy, request.Skip(), request.PageCount);

        return ApiResponse.Success(userPlayChallenges.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = userPlayChallenges.TotalCount,
            Page = request.Page
        });
    }
}
