using System.Security.Claims;

namespace GM.Data.Helpers;

public static class ClaimsPrincipalHelper
{
    public static int GetUserId(this ClaimsPrincipal principal)
    {
        var value = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(value, out var id) ? id : 0;
    }

    public static string GetName(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimTypes.Name)?.Value;
    }

    public static string GetEmail(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimTypes.Email)?.Value;
    }

    public static string GetPhoneNumber(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimTypes.MobilePhone)?.Value;
    }

    public static string GetRole(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimTypes.Role)?.Value;
    }

    public static TEnum? GetUserRole<TEnum>(this ClaimsPrincipal principal) where TEnum : struct
    {
        var value = principal.FindFirst(ClaimTypes.Role)?.Value;
        return Enum.TryParse(value, out TEnum role) ? role : null;
    }
}