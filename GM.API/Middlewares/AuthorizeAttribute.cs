using GM.Data.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GM.API.Middlewares;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly UserRole[] _roles;

    public AuthorizeAttribute(UserRole[] roles)
    {
        _roles = roles.ToArray();
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        var user = context.HttpContext.User;
        if (user.GetUserId() == 0)
        {
            throw new ApiException(ErrorCode.UNAUTHORIZED);
        }
        else
        {
            var userRole = user.GetUserRole<UserRole>();
            if (userRole == null)
            {
                throw new ApiException(ErrorCode.UNAUTHORIZED);
            }
            else
            {
                if (_roles.Any() && !_roles.Contains(userRole.Value))
                {
                    throw new ApiException(ErrorCode.FORBIDDEN);
                }
            }
        }
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{
}