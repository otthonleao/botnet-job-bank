using JobBank.Core.Data.Context;
using JobBank.Core.Models;

namespace JobBank.Core.Repositories.Jobs;

public class JobRepository(JobBankDbContext context) : IJobRepository
{
    private readonly JobBankDbContext _context = context;

    public bool ExistsById(int id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Job> FindAll()
    {
        throw new NotImplementedException();
    }

    public Job Create(Job model)
    {
        throw new NotImplementedException();
    }

    public Job? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Job Update(Job model)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}
