using JobBank.Core.Repositories.Jobs;

namespace JobBank.Core.Config;

public static class RepositoriesConfig
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJobRepository, JobRepository>();
    }
}