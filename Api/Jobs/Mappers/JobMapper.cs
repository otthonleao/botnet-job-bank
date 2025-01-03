using JobBank.Api.Jobs.Dtos;
using JobBank.Core.Models;
using JobBank.Core.Repositories;

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

    public PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pagedResult)
    {
        return new PagedResponse<JobSummaryResponse>
        {
            Items = pagedResult.Items.Select(ToSummaryResponse).ToList(),
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            FirstPage = pagedResult.FirstPage,
            LastPage = pagedResult.LastPage,
            TotalPages = pagedResult.TotalPages,
            TotalElements = pagedResult.TotalElements,
            HasPreviousPage = pagedResult.HasPreviousPage,
            HasNextPage = pagedResult.HasNextPage
        };
    }

    public Job ToModel(JobRequest jobRequest)
    {
        return new Job()
        {
            Title = jobRequest.Title,
            Salary = jobRequest.Salary,
            Requirements = string.Join(";", jobRequest.Requirements)
        };
    }
    
    
}