using GM.API.Models.Auths;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GM.API.Services;

public interface IAuthService
{
    Task<ApiResponse> Auth(AuthModel authModel, UserRole userRole);
}

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<ApiResponse> Auth(AuthModel authModel, UserRole userRole)
    {
        const int expiresIn = 3600;
        int fistLogin = 1;
        var user = await _userRepository.FindOneAsync(new Expression<Func<User, bool>>[]
        {
            u => u.IsDeleted == false
                 && u.Username == authModel.Username
        });

        if (user == null)
            throw new ApiException(
                ApiMessage.InvalidUsernameOrPassword,
                ErrorCode.INVALID_USERNAME_OR_PASSWORD);

        var passwordHasher = new PasswordHasher<User>();
        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(
            new User(),
            user.Password,
            authModel.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
            throw new ApiException(
                ApiMessage.InvalidUsernameOrPassword,
                ErrorCode.INVALID_USERNAME_OR_PASSWORD);

        if (user.AccessToken == null) fistLogin = 0;
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role.ToString()),
            new(ClaimTypes.Email, user.Email)
        };
        var accessToken = _jwtService.GenerateJwtToken(claims, expiresIn);

        var refreshToken = _jwtService.GenerateRefreshToken(user.Id);
        user.AccessToken = accessToken;
        user.RefreshToken = refreshToken;

        _userRepository.Update(user);
        await _userRepository.SaveChangeAsync();

        return ApiResponse.Success(new
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresIn = expiresIn.ToString(),
            Name = user.Fullname,
            Role = user.Role,
            FistLogin = fistLogin
        });
    }
}