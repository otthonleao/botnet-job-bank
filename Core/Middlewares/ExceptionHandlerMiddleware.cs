using System.Text.Json;
using JobBank.Api.Jobs.Common;
using JobBank.Core.Exceptions;

namespace JobBank.Core.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ModelNotFoundException ex)
        {
            await HandleModelNotFoundExceptionAsync(context, ex);
        }
    }

    private Task HandleModelNotFoundExceptionAsync(HttpContext context, ModelNotFoundException ex)
    {
        var body = new ErrorResponse
        {
            Status = StatusCodes.Status404NotFound,
            Error = "Not Found",
            Cause = ex.GetType().Name,
            Message = ex.Message,
            Timestamp = DateTime.UtcNow
        };
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body));
    }
}