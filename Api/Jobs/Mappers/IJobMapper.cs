using JobBank.Api.Jobs.Dtos;
using JobBank.Core.Models;
using JobBank.Core.Repositories;

namespace JobBank.Api.Jobs.Mappers;

public interface IJobMapper
{
    JobSummaryResponse ToSummaryResponse(Job job);
    JobDetailResponse ToDetailResponse(Job job);
    PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pagedResult);
    Job ToModel(JobRequest jobRequest);
}