using FluentValidation;
using JobBank.Api.Jobs.Dtos;

namespace JobBank.Api.Jobs.Validators;

public class JobRequestValidator : AbstractValidator<JobRequest>
{
    public JobRequestValidator()
    {
        RuleFor(j => j.Title).NotEmpty().MaximumLength(100);
        RuleFor(j => j.Salary).GreaterThan(0);
        RuleFor(j => j.Requirements).NotEmpty();
    }
}