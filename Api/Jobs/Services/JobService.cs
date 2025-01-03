using JobBank.Api.Jobs.Dtos;
using JobBank.Api.Jobs.Mappers;
using JobBank.Core.Exceptions;
using JobBank.Core.Models;
using JobBank.Core.Repositories.Jobs;

namespace JobBank.Api.Jobs.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;

    public JobService(IJobRepository jobRepository, IJobMapper jobMapper)
    {
        _jobRepository = jobRepository;
        _jobMapper = jobMapper;
    }

    public ICollection<Job> FindAll()
    {
        return _jobRepository.FindAll();
    }
    
    public Job FindById(int id)
    {
        var job = _jobRepository.FindById(id);
        if (job is null)
        {
            throw new ModelNotFoundException($"Job with id {id} not found");
        }
        return job;
    }

    public JobDetailResponse Create(JobRequest jobRequest)
    {
        var job = _jobMapper.ToJob(jobRequest);
        var createdJob = _jobRepository.Create(job);
        return _jobMapper.ToDetailResponse(createdJob);
    }
    
    public Job Update(int id, Job job)
    {
        if (!_jobRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Job with id {id} not found");
        }
        job.Id = id;
        return _jobRepository.Update(job);
    }
    
    public void Delete(int id)
    {
        if (!_jobRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Job with id {id} not found");
        }
        
        _jobRepository.DeleteById(id);
    }
}