using JobBank.Core.Data.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace JobBank.Core.Data.Context;

public class JobBankDbContext(DbContextOptions<JobBankDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new JobEntityConfig());
    }
}