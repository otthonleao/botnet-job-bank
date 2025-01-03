using FluentValidation;
using JobBank.Api.Jobs.Dtos;

namespace JobBank.Api.Jobs.Validators;

public class JobRequestValidator : AbstractValidator<JobRequest>
{
    public JobRequestValidator()
    {
        RuleFor(j => j.Title).NotEmpty().MaximumLength(100)
            .OverridePropertyName("title").WithMessage("Title is required and must not exceed 100 characters");
        RuleFor(j => j.Salary).GreaterThan(0)
            .OverridePropertyName("salary").WithMessage("Salary must be greater than 0");
        RuleFor(j => j.Requirements).NotEmpty()
            .OverridePropertyName("requirements");
    }
}