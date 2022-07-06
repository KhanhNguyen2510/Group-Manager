using GM.API.Models.Nccs;

namespace GM.API.Services;

public interface INccService 
{
    Task<List<NCC>> GetNCCs();
    Task<NCC> GetNccById(int nccId);
    Task<ApiResponse> Create(int creatorId, int managerId, CreateNccModel request);
    Task<ApiResponse> Update(int managerId,int nccId, UpdateNccModel request);
    Task<ApiResponse> Delete(int managerId, int nccId);
    Task<ApiResponse> NccById(int managerId, int nccId);
    Task<ApiResponse> Nccs(int managerId, GetNccModel request);
}

public class NccService : INccService
{
    private readonly INccRepository _nccRepository;
    private readonly IUserService _userService;
    private readonly INcService _ncService;

    public NccService(
        INccRepository nccRepository,
        IUserService userService,
        INcService ncService
    )
    {
        _ncService = ncService;
        _nccRepository = nccRepository;
        _userService = userService;
    }

    public async Task<List<NCC>> GetNCCs()
    {
        var nccs = await _nccRepository.FindAsync(
             new Expression<Func<NCC, bool>>[]
             {
                u => u.IsDeleted == false
             }, string.Empty, string.Empty);
        if (nccs == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return nccs;
    }

    public async Task<NCC> GetNccById(int nccId)
    {
        var nccById = await _nccRepository.FindOneAsync(new Expression<Func<NCC, bool>>[]
        {
            ncc => ncc.IsDeleted == false
                   && ncc.Id == nccId
        });
        if (nccById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_ALREDY_EXISTS);
        return nccById;
    }

    public async Task<ApiResponse> Create(int creatorId, int managerId, CreateNccModel request)
        // cho key thêm vào nc nào ncId bắt buộc
    {
        await _ncService.GetNcById(managerId);
        var data = new NCC
        {
            Name = request.name,
            BirthDay = request.birthDay,
            PhoneNumber = request.phoneNumber,
            Address = request.address,
            ManagerId = managerId,
            CreatorId = creatorId
        };

        await _nccRepository.InsertAsync(data);
        await _nccRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> Update(int managerId, int nccId, UpdateNccModel request)
    {
        var nccById = await GetNccById(nccId);

        if (nccById.CreatorId != managerId)
            throw new ApiException(
                ApiMessage.NotRole, ErrorCode.NOT_ROLE);

        nccById.Name = request.name ?? nccById.Name;
        nccById.BirthDay = request.birthDay ?? nccById.BirthDay;
        nccById.PhoneNumber = request.phoneNumber ?? nccById.PhoneNumber;
        nccById.Address = request.address ?? nccById.Address;
        nccById.UpdateDate = DateTime.Now;

        _nccRepository.Update(nccById);
         await _nccRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> Delete(int managerId, int nccId)
    {
        var nccById = await GetNccById(nccId);

        if (nccById.CreatorId != managerId)
            throw new ApiException(
                ApiMessage.NotRole, ErrorCode.NOT_ROLE);

        nccById.IsDeleted = true;
        nccById.TimeDelete = DateTime.Now;
        nccById.UpdateDate = DateTime.Now;

        _nccRepository.Update(nccById);
        await _nccRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> NccById(int managerId, int nccId)
    {
        var nccById = await GetNccById(nccId);
        var userById = await _userService.GetUserByIdAsync(managerId);

        if (userById.Role == UserRole.Nco)
        {
            if (nccById.CreatorId != managerId)
                throw new ApiException(
                    ApiMessage.NotRole, ErrorCode.NOT_ROLE);
        }

        return ApiResponse.Success(nccById);
    }

    private async Task<List<Expression<Func<NCC, bool>>>> QueryNcc(int managerId, GetNccModel request)
    {
        var query = new List<Expression<Func<NCC, bool>>> 
        { 
            x => x.IsDeleted == false
        };

        var user = await _userService.GetUserByIdAsync(managerId);

        if (user.Role == UserRole.Nco)
            query.Add(x => x.CreatorId == managerId);

        if (request.managerId != null)
            query.Add(x => x.ManagerId == request.managerId);

        if (!string.IsNullOrEmpty(request.keyWord))
            query.Add(x => x.Name.Contains(request.keyWord)
                           || x.Id.ToString().Contains(request.keyWord)
                           || x.PhoneNumber.Contains(request.keyWord)
                           || x.Address.Contains(request.keyWord));

        if (request.nccId != null)
            query.Add(x => x.Id == request.nccId);

        return query;
    }

    public async Task<ApiResponse> Nccs(int managerId, GetNccModel request)
    {
        var query = await QueryNcc(managerId, request);

        var nccs = await _nccRepository.FindAsync(query.ToArray(),
            request.OrderBy, request.Skip(), request.PageCount);

        return ApiResponse.Success(nccs.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = nccs.TotalCount,
            Page = request.Page
        });
    }
}

