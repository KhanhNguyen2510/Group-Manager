using GM.API.Middlewares;

namespace GM.API.Models;

public static class SystemBase
{
    public static int ManagerId => AuthMiddleware.UserId ?? 0;
    public const string FistPassword = "123456@";
}
