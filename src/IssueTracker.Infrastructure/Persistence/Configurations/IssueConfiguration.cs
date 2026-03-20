using IssueTracker.Domain.Issues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IssueTracker.Infrastructure.Persistence.Configurations;

public sealed class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> b)
    {
        b.ToTable("issues");

        b.HasKey(x => x.Id);

        b.Property(x => x.Number).IsRequired();

        b.Property(x => x.Title).HasMaxLength(300).IsRequired();
        b.Property(x => x.Description).HasMaxLength(10_000);

        b.Property(x => x.Status).IsRequired();

        b.Property(x => x.CreatedAt).IsRequired();
        b.Property(x => x.UpdatedAt);

        b.HasOne(x => x.Project)
            .WithMany(p => p.Issues)
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // unique per-project issue number
        b.HasIndex(x => new { x.ProjectId, x.Number }).IsUnique();
    }
}