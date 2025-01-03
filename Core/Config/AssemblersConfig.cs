using JobBank.Api.Common.Assemblers;
using JobBank.Api.Jobs.Assemblers;
using JobBank.Api.Jobs.Dtos;

namespace JobBank.Core.Config;

public static class AssemblersConfig
{
    public static void RegisterAssemblers(this IServiceCollection services)
    {
        services.AddScoped<IAssemblerHetoas<JobSummaryResponse>, JobSummaryAssemblerHetoas>();
        services.AddScoped<IAssemblerHetoas<JobDetailResponse>, JobDetailAssemblerHetoas>();
    }
}