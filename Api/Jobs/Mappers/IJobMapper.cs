using JobBank.Api.Jobs.Dtos;
using JobBank.Core.Models;

namespace JobBank.Api.Jobs.Mappers;

public interface IJobMapper
{
    JobSummaryResponse ToSummaryResponse(Job job);
    JobDetailResponse ToDetailResponse(Job job);
    Job ToModel(JobRequest jobRequest);
}