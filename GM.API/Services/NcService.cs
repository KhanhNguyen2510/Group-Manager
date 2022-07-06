global using GM.Data.Repositories;
global using System.Linq.Expressions;
using GM.API.Models.Ncs;

namespace GM.API.Services;

public interface INcService
{
    Task<NC> GetNcById(int ncId);
    Task<ApiResponse> NcById(int ncId);
    Task<ApiResponse> Ncs(int managerId,GetNCsModel request);
    Task<ApiResponse> Create(int creatorId, int managerId, CreateNcModel request);
    Task<ApiResponse> Update(int ncId, UpdateNcModel request);
    Task<ApiResponse> Delete(int ncId);
}

public class NcService : INcService
{
    private readonly INcRepository _ncRepository;
    private readonly IUserService _userService;

    public NcService(
        INcRepository ncRepository,
        IUserService userService
    )
    {
        _userService = userService;
        _ncRepository = ncRepository;
    }

    public async Task<ApiResponse> Create(int managerId, int creatorId, CreateNcModel request)
    {
        var userById= await _userService.GetUserByIdAsync(managerId);
        if (userById.Role != UserRole.Nco)
            throw new ApiException(
                ApiMessage.NotRole, ErrorCode.NOT_FOUND);
        var data = new NC
        {
            Name = request.name,
            Note = request.note,
            ManagerId = managerId,
            CreatorId = creatorId
        };

        await _ncRepository.InsertAsync(data);
        await _ncRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }
    
    public async Task<NC> GetNcById(int ncId)
    {
        var ncById = await _ncRepository.FindOneAsync(new Expression<Func<NC, bool>>[]
        {
            nc => nc.IsDeleted == false
                  && nc.Id == ncId
        });
        if (ncById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_ALREDY_EXISTS);
        return ncById;
    }

    public async Task<ApiResponse> Update(int ncId, UpdateNcModel request)
    {
        var ncById = await GetNcById(ncId);

        if (request.managerId != null)
        {
            var userById = await _userService.GetUserByIdAsync((int)request.managerId);
            if (userById.Role != UserRole.Nco)
                throw new ApiException(
                    ApiMessage.NotRole, ErrorCode.NOT_FOUND);
            ncById.ManagerId = request.managerId ?? ncById.ManagerId;
        }

        ncById.Name = request.name ?? ncById.Name;
        ncById.Note = request.note ?? ncById.Note;
        ncById.UpdateDate = DateTime.Now;

        _ncRepository.Update(ncById);
        await _ncRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> Delete(int ncId)
    {
        var ncById = await GetNcById(ncId);

        ncById.IsDeleted = true;
        ncById.TimeDelete = DateTime.Now;
        ncById.UpdateDate = DateTime.Now;

        _ncRepository.Update(ncById);
        await _ncRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> NcById(int ncId)
    {
        var ncById = await GetNcById(ncId);

        return ApiResponse.Success(ncById);
    }

    private static async Task<List<Expression<Func<NC, bool>>>> QueryNc(int managerId, GetNCsModel request)
    {
        var query = new List<Expression<Func<NC, bool>>> { x => x.IsDeleted == false };

        if (request.managerId != null)
            query.Add(x => x.ManagerId == request.managerId);

        if (!string.IsNullOrEmpty(request.keyWord))
            query.Add(x => x.Name.Contains(request.keyWord)
                           || x.Note.Contains(request.keyWord));
        if (request.ncId != null)
            query.Add(x => x.Id == request.ncId);

        return await Task.FromResult(query);
    }

    public async Task<ApiResponse> Ncs(int managerId, GetNCsModel request)
    {
        var query = await QueryNc(managerId, request);

        var ncs = await _ncRepository.FindIncludeAsync(query.ToArray(),
            request.OrderBy, "Nccs", request.Skip(), request.PageCount);

        return ApiResponse.Success(ncs.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = ncs.TotalCount,
            Page = request.Page
        });
    }
}
