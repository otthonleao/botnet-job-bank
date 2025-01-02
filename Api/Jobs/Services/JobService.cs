using JobBank.Core.Models;
using JobBank.Core.Repositories.Jobs;

namespace JobBank.Api.Jobs.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public ICollection<Job> FindAll()
    {
        return _jobRepository.FindAll();
    }
}