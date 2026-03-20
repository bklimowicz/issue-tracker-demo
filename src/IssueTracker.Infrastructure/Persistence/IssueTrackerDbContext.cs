using IssueTracker.Domain.Issues;
using IssueTracker.Domain.Projects;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Infrastructure.Persistence;

public sealed class IssueTrackerDbContext : DbContext
{
    public IssueTrackerDbContext(DbContextOptions<IssueTrackerDbContext> options) : base(options) { }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Issue> Issues => Set<Issue>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IssueTrackerDbContext).Assembly);
    }
}