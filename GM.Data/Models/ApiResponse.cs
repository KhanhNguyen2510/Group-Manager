using System.Text.Json.Serialization;

namespace GM.Data.Models;

public class ApiResponse<T> : ApiResponse
{
    public T Data { get; set; }
}

public class ApiPaginationResponse<T> : ApiResponse
{
    public IEnumerable<T> Data { get; set; }

    [JsonIgnore] public PaginationHeaders PaginationHeaders { get; set; }
}

public class ApiResponse
{
    public int? StatusCode { get; set; }

    public string StatusMessage { get; set; }


    public static ApiResponse Success()
    {
        return Create(ApiStatusCode.Success, "Success");
    }

    public static ApiResponse<T> Success<T>(T data)
    {
        return Create(data, ApiStatusCode.Success, "Success");
    }

    public static ApiPaginationResponse<T> Success<T>(IEnumerable<T> data, PaginationHeaders headers)
    {
        return Create(data, headers, ApiStatusCode.Success, "Success");
    }

    public static ApiResponse Create(ApiStatusCode statusCode, string statusMessage)
    {
        return new()
        {
            StatusCode = (int) statusCode,
            StatusMessage = statusMessage,
        };
    }

    public static ApiResponse<T> Create<T>(T data, ApiStatusCode statusCode, string statusMessage)
    {
        return new()
        {
            Data = data,
            StatusCode = (int) statusCode,
            StatusMessage = statusMessage,
        };
    }

    public static ApiPaginationResponse<T> Create<T>(IEnumerable<T> data, PaginationHeaders paginationHeaders,
        ApiStatusCode statusCode, string statusMessage)
    {
        return new()
        {
            Data = data,
            PaginationHeaders = paginationHeaders,
            StatusCode = (int) statusCode,
            StatusMessage = statusMessage,
        };
    }
}

public class PaginationHeaders
{
    public int Page { get; set; }
    public int TotalCount { get; set; }
    public int Limit { get; set; }
}

public enum ApiStatusCode
{
    Success = 200,
    ClientError = 400,
    ClientInvalidOrMissingParameters = 401,
    ServerError = 500,
    NotFound = 404
}