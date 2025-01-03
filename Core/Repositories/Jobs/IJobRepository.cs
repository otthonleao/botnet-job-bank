using JobBank.Core.Models;

namespace JobBank.Core.Repositories.Jobs;

public interface IJobRepository : ICrudRepository<Job, int>, IPagedRespository<Job>
{
    
}