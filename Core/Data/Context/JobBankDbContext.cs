using JobBank.Core.Data.EntityConfigs;
using JobBank.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBank.Core.Data.Context;

public class JobBankDbContext : DbContext
{
    public JobBankDbContext(DbContextOptions<JobBankDbContext> options) : base(options)
    {
    }

    public DbSet<Job> Jobs => Set<Job>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new JobEntityConfig());
    }
}