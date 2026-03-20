using System;
using IssueTracker.Domain.Projects;

namespace IssueTracker.Domain.Issues;

public sealed class Issue
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }

    public int Number { get; set; } // unique per project

    public required string Title { get; set; }
    public string? Description { get; set; }

    public IssueStatus Status { get; set; } = IssueStatus.Open;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}