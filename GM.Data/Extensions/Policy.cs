using GM.Data.Helpers;
using System.Text.Json;

namespace GM.Data.Extensions;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToSnake();
    }
}