using System.Net;

namespace WebApplication.Pages;
public class ErrorHandling
{
    private readonly ILogger<ErrorHandling> _logger;
    private readonly RequestDelegate _next;
    public ErrorHandling(ILogger<ErrorHandling> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            string urlEncodedValue = WebUtility.UrlEncode(ex.Message);
            _logger.LogError(ex, "");
            context.Response.Redirect($"../ExceptionError/{urlEncodedValue}/");
        }
    }
}

public static class ErrorHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandling>();
    }
}