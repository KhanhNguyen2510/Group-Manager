namespace Main.Api.Middlewares;

public class HandleResponseMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public HandleResponseMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<HandleResponseMiddleware>();
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
            _logger.LogInformation(
                "Http Response Information | Method: {Method} | Path: {Path} | Status Code: {StatusCode} | QueryString: {QueryString}",
                context.Request.Method.ToUpper(),
                context.Request.Path,
                context.Response.StatusCode,
                context.Request.QueryString
            );
        }
        catch (ApiException apiException)
        {
            await HandleExceptionAsync(context,
                new ApiException(apiException.Message, apiException.Result, apiException.StatusCode));
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Detail Exception");
            await HandleExceptionAsync(context, new ApiException());
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, ApiException apiException)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) apiException.StatusCode;
        await context.Response.WriteAsJsonAsync(new
        {
            apiException.Message,
            apiException.StatusCode,
            apiException.Result
        });

        _logger.LogError(
            "Http Response Error | Method: {Method} | Path: {Path} | Status Code: {StatusCode} | QueryString: {QueryString} Message: {Message}",
            context.Request.Method.ToUpper(),
            context.Request.Path,
            context.Response.StatusCode,
            $"{context.Request.QueryString}{Environment.NewLine}",
            apiException.Message
        );
    }
}