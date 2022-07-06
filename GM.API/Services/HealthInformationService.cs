using GM.API.Models.HealthInformations;
using System.Linq;

namespace GM.API.Services;

public interface IHealthInformationService
{
    Task<ApiResponse> Create(int creatorId,int nccId, CreateHealInformationModel request);
    Task<ApiResponse> Update(int creatorId, int healthId, UpdateHealInformationModel request);
    Task<ApiResponse> Delete(int creatorId, int healthId);
    Task<ApiResponse> GetHealthInformationById(int creatorId, int healthId);
    Task<ApiResponse> GetHealthInformation(int creatorId, GetHealthInformationModel request);
}
public class HealthInformationService : IHealthInformationService
{
    private readonly IHealthInformationRepository _healthInformationRepository;
    private readonly IUserService _userService;
    public HealthInformationService(
        IHealthInformationRepository healthInformationRepository
        , IUserService userService)
    {
        _healthInformationRepository = healthInformationRepository;
        _userService = userService;
    }

    public async Task<ApiResponse> Create(int creatorId,int nccId, CreateHealInformationModel request)
    {
        var data = new HealthInformation
        {
            NccId = nccId,
            Height = request.height,
            Weight = request.weight,
            Slush = request.slush,
            CreatorId = creatorId
        };

        await _healthInformationRepository.InsertAsync(data);
        await _healthInformationRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<HealthInformation> HealthByIdAsync(int healId)
    {
        var healthById = await _healthInformationRepository.FindOneAsync(new Expression<Func<HealthInformation, bool>>[]
        {
            x => x.IsDeleted == false
                 && x.Id == healId
        });
        if (healthById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return healthById;
    }

    public async Task<ApiResponse> Update(int creatorId, int healthId, UpdateHealInformationModel request)
    {
        var healthById = await HealthByIdAsync(healthId);

        if (healthById.CreatorId != creatorId)
            throw new ApiException(
                ApiMessage.NotRole, ErrorCode.NOT_ROLE);
        
        healthById.Height = request.height ?? healthById.Height;
        healthById.Weight = request.weight ?? healthById.Weight;
        healthById.Slush = request.slush ?? healthById.Slush;
        healthById.UpdateDate = DateTime.Now;

        _healthInformationRepository.Update(healthById);
        await _healthInformationRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> Delete(int creatorId, int healthId)
    {
        var healthById = await HealthByIdAsync(healthId);

        if (healthById.CreatorId != creatorId)
            throw new ApiException(
                ApiMessage.NotRole, ErrorCode.NOT_ROLE);

        healthById.IsDeleted = true;
        healthById.UpdateDate = DateTime.Now;
        healthById.TimeDelete = DateTime.Now;

        _healthInformationRepository.Update(healthById);
        await _healthInformationRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<HealthInformation> GetHealthByIdAsync(int creatorId, int healId)
    {
        var userIds = await _userService.GetUserRoleAdmin();
        var healthById = await _healthInformationRepository.FindOneAsync(new Expression<Func<HealthInformation, bool>>[]
        {
            x => x.IsDeleted == false
                && userIds.Contains((int)x.CreatorId) || x.CreatorId == creatorId
                && x.Id == healId
        });
        if (healthById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return healthById;
    }

    public async Task<ApiResponse> GetHealthInformationById(int creatorId ,int healthId)
    {
        var healthById = await GetHealthByIdAsync(creatorId,healthId);

        return ApiResponse.Success(healthById);
    }
    
    private async Task<List<Expression<Func<HealthInformation, bool>>>> QueryHealth(int creatorId, GetHealthInformationModel request)
    {
        var query = new List<Expression<Func<HealthInformation, bool>>>(){x=>x.IsDeleted == false};

        var user = await _userService.GetUserByIdAsync(creatorId);
        var userIds = await _userService.GetUserRoleAdmin();
        if (user.Role == UserRole.Nco)
            query.Add(x => x.CreatorId == creatorId 
                           || userIds.Contains((int)x.CreatorId));
        
        if (request.creatorId != null)
            query.Add(x => x.CreatorId == request.creatorId
                           || userIds.Contains((int)x.CreatorId));

        if (request.nccId != null)
            query.Add(x => x.NccId == request.nccId);

        if (request.height != null)
            query.Add(x => x.Height == request.height);

        if (request.weight != null)
            query.Add(x => x.Weight == request.weight);

        if (request.slush != null)
            query.Add(x => x.Slush == request.slush);
        return query;
    }

    public async Task<ApiResponse> GetHealthInformation(int creatorId, GetHealthInformationModel request)
    {
        var query = await QueryHealth(creatorId, request);

        var healthInformation = await _healthInformationRepository.FindAsync(query.ToArray(),
            request.OrderBy, request.Skip(), request.PageCount);

        return ApiResponse.Success(healthInformation.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = healthInformation.TotalCount,
            Page = request.Page
        });
    }
}
