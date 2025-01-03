using JobBank.Core.Models;

namespace JobBank.Api.Jobs.Services;

public interface IJobService
{
    ICollection<Job> FindAll();
    Job FindById(int id);
    Job Create(Job job);
    Job Update(int id, Job job);
    void Delete(int id);
}