using JobBank.Api.Jobs.Dtos;
using JobBank.Core.Models;

namespace JobBank.Api.Jobs.Mappers;

public class JobMapper : IJobMapper
{
    public JobSummaryResponse ToSummaryResponse(Job job)
    {
        return new JobSummaryResponse()
        {
            Id = job.Id,
            Title = job.Title
        };
    }

    public JobDetailResponse ToDetailResponse(Job job)
    {
        return new JobDetailResponse()
        {
            Id = job.Id,
            Title = job.Title,
            Salary = job.Salary,
            Requirements = job.Requirements.Split(";")
        };
    }

    public Job ToJob(JobRequest jobRequest)
    {
        return new Job()
        {
            Title = jobRequest.Title,
            Salary = jobRequest.Salary,
            Requirements = string.Join(";", jobRequest.Requirements)
        };
    }
}