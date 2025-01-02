using JobBank.Core.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace JobBank.Core.Config;

public static class DatabaseConfig
{
    public static void RegisterDatabase(this IServiceCollection services, ConfigurationManager builderConfiguration)
    {
        services.AddDbContext<JobBankDbContext>(options =>
            options.UseNpgsql("Host=localhost;Port=5433;Database=dotnet-job-bank_db;Username=user;Password=senha123"));
    }
}
