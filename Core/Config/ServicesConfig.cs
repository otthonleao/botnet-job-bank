using JobBank.Api.Jobs.Services;

namespace JobBank.Core.Config;

public static class ServicesConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IJobService, JobService>();
    }
}