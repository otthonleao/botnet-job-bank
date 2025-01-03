using JobBank.Api.Jobs.Dtos;
using JobBank.Core.Models;

namespace JobBank.Api.Jobs.Services;

public interface IJobService
{
    ICollection<JobSummaryResponse> FindAll();
    JobDetailResponse FindById(int id);
    JobDetailResponse Create(JobRequest jobRequest);
    JobDetailResponse Update(int id, JobRequest jobRequest);
    void Delete(int id);
}