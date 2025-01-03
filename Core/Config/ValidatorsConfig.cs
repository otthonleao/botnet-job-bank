using FluentValidation;
using JobBank.Api.Jobs.Dtos;
using JobBank.Api.Jobs.Validators;

namespace JobBank.Core.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<JobRequest>, JobRequestValidator>();
    }
}