using GM.API.Models.CheckIns;

namespace GM.API.Services;

public interface ICheckInService
{
    Task<ApiResponse> Create(int managerId, CreateCheckInModel request);
    Task<ApiResponse> Update(int managerId, int checkInId, 
        UpdateCheckInModel request);

    Task<ApiResponse> Delete(int managerId, int checkInId, 
        DeleteCheckInModel request);

    Task<ApiResponse> GetCheckInById(int managerId, int checkInId);
    Task<ApiResponse> CheckIns(int managerId, GetCheckInsModel request);

}
public class CheckInService : ICheckInService
{
    private readonly ICheckInRepository _checkInRepository;
    private readonly IInvoiceService _invoiceService;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IUserService _userService;
    private readonly INcService _ncService;
    public CheckInService(
        INcService ncService,
        IUserService userService,
        ICheckInRepository checkInRepository,
        IInvoiceService invoiceService,
        IInvoiceRepository invoiceRepository
        )
    {
        _ncService = ncService;
        _userService = userService;
        _invoiceRepository = invoiceRepository;
        _checkInRepository = checkInRepository;
        _invoiceService = invoiceService;
    }

    private async Task<List<CheckIn>> GetCheckInsByIdAsync(int managerId, int invoiceId)
    {
        return await _checkInRepository.FindAsync(new Expression<Func<CheckIn, bool>>[]
        {
            c => c.IsDeleted == false
                 && c.InvoiceId == invoiceId
                 && c.CreatorId == managerId
        }, string.Empty, string.Empty);
    }

    public async Task<List<int>> GetInvoices(int managerId , int ncId)
    {
        var invoices = await _invoiceRepository.FindAsync(new Expression<Func<Invoice, bool>>[]
        {
            c => c.IsDeleted == false
                 && c.NcId == ncId
                 && c.Status == Status.UnFinished
                 && c.CreatorId == managerId
        }, string.Empty, string.Empty);

        var invoiceIds = invoices.Select(x => x.Id).ToList();

        return invoiceIds;
    }


    public async Task GetCreateCheckInAsync(int managerId, CreateCheckInModel request)
    {
        ///Danh sách các check in 
        var checkInById = await GetCheckInsByIdAsync(managerId, (int)request.invoiceId);

        var checkInBySession = checkInById.LastOrDefault(
            x => x.TimeOfDay.Date == DateTime.Now.Date
                 && x.Session == request.session);
        if (checkInBySession != null)
            throw new ApiException(
                $"{ApiMessage.SessionHaveBeenUsing} is {checkInBySession.Id}", ErrorCode.ALREADY_EXISTS);

        var invoiceById = await _invoiceService.GetInvoiceByIdAsync(managerId, (int)request.invoiceId);

        if (invoiceById.Remain == 0
            || invoiceById.Status == Status.Finished)
            throw new ApiException(
                $"{ApiMessage.Shortage} is {invoiceById.Id}", ErrorCode.NOT_FOUND);

        var remain = invoiceById.Remain - 1;

        var data = new CheckIn
        {
            InvoiceId = (int)request.invoiceId,
            Duration = invoiceById.Duration,
            Remain = remain,
            TimeOfDay = DateTime.Now,
            Session = request.session,
            NcId = invoiceById.NcId,
            CreatorId = managerId
        };

        if (remain == 0)
            invoiceById.Status = Status.Finished;

        invoiceById.Remain = remain;

        await _checkInRepository.InsertAsync(data);
        await _checkInRepository.SaveChangeAsync();

        _invoiceRepository.Update(invoiceById);
        await _invoiceRepository.SaveChangeAsync();
    }
  
   
    //1 sesion chỉ được điểm danh 1 lần trong ngày 
    //admin xem check in
    public async Task<ApiResponse> Create(int managerId, CreateCheckInModel request)
    {
        if (request.ncId is > 0)
        {
            var invoices = await GetInvoices(managerId, (int)request.ncId);
            foreach (var item in invoices)
            {
                request.invoiceId = item;
                await GetCreateCheckInAsync(managerId, request);
            }
        }
        else
        {
            await GetCreateCheckInAsync(managerId, request);
        }
        return ApiResponse.Success();
    }

    private async Task<CheckIn> GetCheckInByIdAsync(int managerId, int checkInId)
    {
        var checkInById = await _checkInRepository.FindOneAsync(new Expression<Func<CheckIn, bool>>[]
        {
            c => c.IsDeleted == false
                 && c.Id == checkInId
                 && c.CreatorId == managerId
        });

        if (checkInById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return checkInById;
    }

    ///dổi cần kta có chưa  sessiopn
    public async Task<ApiResponse> Update(int managerId,int checkInId, UpdateCheckInModel request)
    {
        var checkInById = await GetCheckInByIdAsync(managerId, checkInId);
        
        var checkInByInvoice = await GetCheckInsByIdAsync(managerId, checkInById.InvoiceId);
        var checkInBySession = checkInByInvoice.LastOrDefault(
            x => x.TimeOfDay.Date == DateTime.Now.Date
                 && x.Session == request.session);

        if (checkInBySession != null)
            throw new ApiException(
                ApiMessage.AlreadyExist, ErrorCode.ALREADY_EXISTS);

        checkInById.Session = request.session ?? checkInById.Session;
        checkInById.UpdateDate = DateTime.Now;

        _checkInRepository.Update(checkInById);
        await _checkInRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }
    // cộng lại invoice
    ///Lý do xóa checkin
    
    public async Task<ApiResponse> Delete(int managerId,int checkInId ,DeleteCheckInModel request)
    {
        var checkInById = await GetCheckInByIdAsync(managerId,checkInId);
        var invoiceById = await _invoiceService.GetInvoiceByIdAsync(managerId, checkInById.InvoiceId);
        invoiceById.Remain += 1;

        checkInById.Note = request.note;
        checkInById.IsDeleted = true;
        checkInById.TimeDelete = DateTime.Now;
        checkInById.UpdateDate = DateTime.Now;
        
        _invoiceRepository.Update(invoiceById);
        _checkInRepository.Update(checkInById);
        
        await _checkInRepository.SaveChangeAsync();
        await _checkInRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    private async Task<CheckIn> GetCheckInById(int checkInId)
    {
        var checkInById = await _checkInRepository.FindOneAsync(new Expression<Func<CheckIn, bool>>[]
        {
            c => c.IsDeleted == false
                 && c.Id == checkInId
        });

        if (checkInById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return checkInById;
    }

    public async Task<ApiResponse> GetCheckInById(int managerId,int checkInId)
    {
        var checkInById = await GetCheckInById(checkInId);
        var user = await _userService.GetUserByIdAsync(managerId);
        if (user.Role == UserRole.Nco)
        {
            if (checkInById.CreatorId != managerId)
                throw new ApiException(
                    ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        }
        return ApiResponse.Success(checkInById);
    }

    private async Task<List<Expression<Func<CheckIn, bool>>>> GetCheckIn(int managerId, GetCheckInsModel request)
    {
        var query = new List<Expression<Func<CheckIn, bool>>>() { x => x.IsDeleted == false };

        var user = await _userService.GetUserByIdAsync(managerId);
        if (user.Role == UserRole.Nco)
            query.Add(x => x.CreatorId == managerId);
        if (request.managerId != null)
            query.Add(x => x.CreatorId == request.managerId);
        if (request.invoiceId != null)
            query.Add(x => x.InvoiceId == request.invoiceId);

        if (request.remain != null)
            query.Add(x => x.Remain == request.remain);

        if (request.session != null)
            query.Add(x => x.Session == request.session);

        return query;
    }

    public async Task<ApiResponse> CheckIns(int managerId, GetCheckInsModel request)
    {
        var query = await GetCheckIn(managerId, request);

        var checkIn = await _checkInRepository.FindAsync<CheckIn>(query.ToArray(),
            request.OrderBy, request.Skip(), request.PageCount);

        return ApiResponse.Success(checkIn.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = checkIn.TotalCount,
            Page = request.Page
        });
    }
}
