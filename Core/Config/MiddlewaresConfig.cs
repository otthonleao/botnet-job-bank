using JobBank.Core.Middlewares;

namespace JobBank.Core.Config;

public static class MiddlewaresConfig
{
    public static void RegisterMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}