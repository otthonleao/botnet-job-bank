using JobBank.Core.Data.EntityConfigs;
using JobBank.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBank.Core.Data.Context;

public class JobBankDbContext(DbContextOptions<JobBankDbContext> options) : DbContext(options)
{
    public DbSet<Job> Jobs => Set<Job>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new JobEntityConfig());
    }
}