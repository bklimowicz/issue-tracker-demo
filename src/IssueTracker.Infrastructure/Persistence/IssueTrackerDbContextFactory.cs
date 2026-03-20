using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IssueTracker.Infrastructure.Persistence;

public sealed class IssueTrackerDbContextFactory : IDesignTimeDbContextFactory<IssueTrackerDbContext>
{
    public IssueTrackerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IssueTrackerDbContext>();
        
        var connectionString =
            Environment.GetEnvironmentVariable("ConnectionStrings__Default") ??
            Environment.GetEnvironmentVariable("ConnectionStrings:Default");
        
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString = "Host=localhost;Port=5432;Database=issuetracker;Username=issuetracker;Password=issuetracker";
        }

        optionsBuilder.UseNpgsql(connectionString);

        return new IssueTrackerDbContext(optionsBuilder.Options);
    }
}