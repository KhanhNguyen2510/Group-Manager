using System.Security.Claims;

namespace GM.API.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public static int? UserId; 

    public async Task Invoke(
        HttpContext context,
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        var accessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtService.ValidateToken(accessToken ?? string.Empty);
        UserId = userId;
        if (userId != null)
        {
            var user = await userRepository.FindOneAsync(userId.Value);
            if (user != null)
            {
                context.User = new ClaimsPrincipal(new ClaimsIdentity(new[]     
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Fullname),
                    new Claim(ClaimTypes.Email, user.Email ?? ""),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                }));
            }

            await _next(context);
            return;
        }

        await _next(context);
    }
}