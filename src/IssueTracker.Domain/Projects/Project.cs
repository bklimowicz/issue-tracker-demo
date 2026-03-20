using System;
using System.Collections.Generic;

namespace IssueTracker.Domain.Projects;

public sealed class Project
{
    public Guid Id { get; set; }
    public required string Key { get; set; } // e.g. "DEMO"
    public required string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public List<Issues.Issue> Issues { get; set; } = [];
}