using FluentValidation;
using JobBank.Api.Jobs.Dtos;
using JobBank.Api.Jobs.Mappers;
using JobBank.Core.Exceptions;
using JobBank.Core.Models;
using JobBank.Core.Repositories;
using JobBank.Core.Repositories.Jobs;

namespace JobBank.Api.Jobs.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;
    private readonly IValidator<JobRequest> _jobRequestValidator;

    public JobService(IJobRepository jobRepository, IJobMapper jobMapper, IValidator<JobRequest> jobRequestValidator)
    {
        _jobRepository = jobRepository;
        _jobMapper = jobMapper;
        _jobRequestValidator = jobRequestValidator;
    }

    public ICollection<JobSummaryResponse> FindAll()
    {
        return _jobRepository.FindAll()
            .Select(job => _jobMapper.ToSummaryResponse(job))
            .ToList();
    }

    public PagedResponse<JobSummaryResponse> FindAll(int page, int size)
    {
        var paginationOption = new PaginationOptions(page, size);
        var pagedResult = _jobRepository.FindAll(paginationOption);
        return _jobMapper.ToPagedSummaryResponse(pagedResult);
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
        _jobRequestValidator.ValidateAsync(jobRequest);
        var job = _jobMapper.ToModel(jobRequest);
        var createdJob = _jobRepository.Create(job);
        return _jobMapper.ToDetailResponse(createdJob);
    }
    
    public JobDetailResponse Update(int id, JobRequest jobRequest)
    {
        _jobRequestValidator.ValidateAsync(jobRequest);
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