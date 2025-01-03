using JobBank.Core.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace JobBank.Core.Config;

public static class DatabaseConfig
{
    public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<JobBankDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database"))
                .LogTo(Console.WriteLine, LogLevel.Information));
    }
}
