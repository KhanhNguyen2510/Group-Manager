using GM.API.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace GM.API.Services;

public interface IUserService
{
    Task<List<int>> GetUserRoleAdmin();
    Task<List<User>> GetUsers();
    Task<ApiResponse> Users(GetUsersModel request);
    Task<User> GetUserByIdAsync(int userId);
    Task<ApiResponse> UserById(int userId);
    Task<ApiResponse> Create(int creatorId, CreateUserModel request);
    Task<ApiResponse> Update(int userId, UpdateUserModel request);
    Task<ApiResponse> UpdateUserRole(int userId, UserRole userRole);
    Task<ApiResponse> RefreshPassWord(int userId, UpdatePasswordModel model);
    Task<ApiResponse> Delete(int userId);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository
    )
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userRepository.FindAsync(new Expression<Func<User, bool>>[]
        {
            user => user.IsDeleted == false
        }, string.Empty, string.Empty);
        return users;
    }

    public async Task<List<int>> GetUserRoleAdmin()
    {
        var users = await _userRepository.FindAsync(new Expression<Func<User, bool>>[]
        {
            user => user.IsDeleted == false
        }, string.Empty, string.Empty);

        var idUsers = users?.Where(x => x.Role == UserRole.Admin).Select(x => x.Id).ToList();
        return idUsers;
    }

    private async Task UserNameExisted(string userName)
    {
        var cUserName = await _userRepository.FindOneAsync(new Expression<Func<User, bool>>[]
        {
            user => user.IsDeleted == false
                    && user.Username == userName
        });

        if (cUserName != null)
            throw new ApiException(
                ApiMessage.AccountAlreadyExists, ErrorCode.ALREADY_EXISTS);
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        var gUserById = await _userRepository.FindOneAsync(new Expression<Func<User, bool>>[]
        {
            user => user.IsDeleted == false
                    && user.Id == userId
        });

        if (gUserById == null)
            throw new ApiException(
                ApiMessage.NotFound, ErrorCode.NOT_FOUND);
        return gUserById;
    }

    public async Task<ApiResponse> Create(int creatorId, CreateUserModel request)
        // nco k duoc tao // k tao mk chi active // xac thuc lai q lần nưa
    {
        await UserNameExisted(request.userName);

        var hasherPassword = new PasswordHasher<User>();

        var password = hasherPassword.HashPassword(new User(), SystemBase.FistPassword);

        var data = new User
        {
            Fullname = request.fullName,
            Username = request.userName,
            Password = password,
            PhoneNumber = request.phoneNumber,
            Role = request.userRole,
            Email = request.email,
            CreatorId = creatorId
        };

        await _userRepository.InsertAsync(data);
        await _userRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> Update(int userId, UpdateUserModel request)
    {
        var userById = await GetUserByIdAsync(userId);

        userById.Fullname = request.fullName ?? userById.Fullname;
        userById.PhoneNumber = request.phoneNumber ?? userById.PhoneNumber;
        userById.UpdateDate = DateTime.Now;

        _userRepository.Update(userById);
        await _userRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> UpdateUserRole(int userId, UserRole userRole)
    {
        var userById = await GetUserByIdAsync(userId);

        userById.Role = userRole;
        userById.UpdateDate = DateTime.Now;

        _userRepository.Update(userById);
        await _userRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> RefreshPassWord(int userId, UpdatePasswordModel model)
    {
        var userById = await GetUserByIdAsync(userId);

        var hasherPassword = new PasswordHasher<User>();
        var password = hasherPassword.HashPassword(new User(), model.newPass);


        var passwordHasher = new PasswordHasher<User>();
        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(
            new User(),
            password,
            model.confirmPass);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
            throw new ApiException(
                ApiMessage.InvalidPassword,
                ErrorCode.INVALID_USERNAME_OR_PASSWORD);


        userById.Password = password;
        userById.UpdateDate = DateTime.Now;

        _userRepository.Update(userById);
        await _userRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> Delete(int userId)
    {
        var userById = await GetUserByIdAsync(userId);

        userById.IsDeleted = true;
        userById.TimeDelete = DateTime.Now;
        userById.UpdateDate = DateTime.Now;

        _userRepository.Update(userById);
        await _userRepository.SaveChangeAsync();

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> UserById(int userId)
    {
        var userById = await GetUserByIdAsync(userId);
        return ApiResponse.Success(userById);
    }

    private static Task<List<Expression<Func<User, bool>>>> QueryUser(GetUsersModel request)
    {
        var query = new List<Expression<Func<User, bool>>> { x => x.IsDeleted == false };

        if (!string.IsNullOrEmpty(request.keyWord))
        {
            query.Add(x => x.Id.ToString().Contains(request.keyWord)
                           || x.PhoneNumber.Contains(request.keyWord)
                           || x.Username.Contains(request.keyWord));
        }

        if (request.userRole != null)
            query.Add(x => x.Role == request.userRole);

        return Task.FromResult(query);
    }

    public async Task<ApiResponse> Users(GetUsersModel request)
    {
        var query = await QueryUser(request);

        var users = await _userRepository.FindAsync(query.ToArray(),
            request.OrderBy, request.Skip(), request.PageCount);

        return ApiResponse.Success(users.Items, new PaginationHeaders
        {
            Limit = request.PageCount,
            TotalCount = users.TotalCount,
            Page = request.Page
        });
    }
}

