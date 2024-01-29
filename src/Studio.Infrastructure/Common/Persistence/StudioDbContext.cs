using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Studio.Application.Common.Interfaces;
using Studio.Domain.Courses;

namespace Studio.Infrastructure.Common.Persistence;

public class StudioDbContext : DbContext, IUnitOfWork
{
    public DbSet<Course> Courses { get; set; } = null!;
    public StudioDbContext(DbContextOptions<StudioDbContext> options) : base(options)
    {
    }

    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}