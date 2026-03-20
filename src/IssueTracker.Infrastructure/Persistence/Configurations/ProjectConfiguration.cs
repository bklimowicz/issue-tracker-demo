using IssueTracker.Domain.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTracker.Infrastructure.Persistence.Configurations;

public sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> b)
    {
        b.ToTable("projects");

        b.HasKey(x => x.Id);

        b.Property(x => x.Key).HasMaxLength(20).IsRequired();
        b.HasIndex(x => x.Key).IsUnique();

        b.Property(x => x.Name).HasMaxLength(200).IsRequired();

        b.Property(x => x.CreatedAt).IsRequired();
    }
}