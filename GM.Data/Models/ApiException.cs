using System.Runtime.Serialization;

namespace GM.Data.Models;

[Serializable]
public class ApiException : Exception
{
    protected ApiException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(
        serializationInfo, streamingContext)
    {
    }

    public ApiException(string message, object result, ErrorCode? statusCode = ErrorCode.SERVER_ERROR) : base(message)
    {
        StatusCode = statusCode ?? ErrorCode.SERVER_ERROR;
        Message = string.IsNullOrEmpty(message) ? StatusCode.ToString() : message;
        Result = result;
    }

    public ApiException(string message, ErrorCode statusCode) : base(message)
    {
        StatusCode = statusCode;
        Message = string.IsNullOrEmpty(message) ? StatusCode.ToString() : message;
    }

    public ApiException(ErrorCode statusCode) : base(statusCode.ToString())
    {
        StatusCode = statusCode;
        Message = StatusCode.ToString();
    }

    public ApiException(string message) : base(message)
    {
        StatusCode = ErrorCode.SERVER_ERROR;
        Message = string.IsNullOrEmpty(message) ? StatusCode.ToString() : message;
    }

    public ApiException() : base("Vui lòng thử lại sau")
    {
    }

    public ErrorCode StatusCode { get; set; } = ErrorCode.SERVER_ERROR;
    public override string Message { get; } = "Vui lòng thử lại sau";
    public object Result { get; set; }
}

public enum ErrorCode
{
    INVALID_USERNAME_OR_PASSWORD = 400,
    INVALID_MOBILE = 400,
    EMAIL_OR_MOBILE_EXISTS = 404,
    OPERATION_NOT_ALLOWED = 400,
    FORBIDDEN = 403,
    UNAUTHORIZED = 401,
    ALREADY_EXISTS = 400,
    NOT_FOUND = 404,
    SERVER_ERROR = 500,
    NOT_ROLE = 400,
    NOT_ALREDY_EXISTS = 400
}