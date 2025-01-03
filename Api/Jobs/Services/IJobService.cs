using JobBank.Api.Jobs.Dtos;
using JobBank.Core.Models;

namespace JobBank.Api.Jobs.Services;

public interface IJobService
{
    ICollection<JobSummaryResponse> FindAll();
    Job FindById(int id);
    JobDetailResponse Create(JobRequest jobRequest);
    Job Update(int id, Job job);
    void Delete(int id);
}