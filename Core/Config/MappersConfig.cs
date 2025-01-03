using JobBank.Api.Jobs.Mappers;

namespace JobBank.Core.Config;

public static class MappersConfig
{
    public static void RegisterMappers(this IServiceCollection services)
    {
        services.AddScoped<IJobMapper, JobMapper>();
    }
}