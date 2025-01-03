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

    public ICollection<JobSummaryResponse> FindAll()
    {
        return _jobRepository.FindAll()
            .Select(job => _jobMapper.ToSummaryResponse(job))
            .ToList();
    }
    
    public JobDetailResponse FindById(int id)
    {
        var job = _jobRepository.FindById(id);
        if (job is null)
        {
            throw new ModelNotFoundException($"Job with id {id} not found");
        }
        return _jobMapper.ToDetailResponse(job);
    }

    public JobDetailResponse Create(JobRequest jobRequest)
    {
        var job = _jobMapper.ToModel(jobRequest);
        var createdJob = _jobRepository.Create(job);
        return _jobMapper.ToDetailResponse(createdJob);
    }
    
    public JobDetailResponse Update(int id, JobRequest jobRequest)
    {
        if (!_jobRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Job with id {id} not found");
        }
        var jobToUpdate = _jobMapper.ToModel(jobRequest);
        jobToUpdate.Id = id;
        var updatedJob = _jobRepository.Update(jobToUpdate);
        return _jobMapper.ToDetailResponse(updatedJob);
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