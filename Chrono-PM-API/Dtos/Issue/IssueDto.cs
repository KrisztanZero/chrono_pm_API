using Chrono_PM_API.Enums;

namespace Chrono_PM_API.Dtos.Issue;

public class IssueDto
{
    public string? Id { get; set; }
    public string? AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Project { get; set; }
    public IssueType? Type { get; set; }
    public IssuePriority? Priority { get; set; }
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public DateTime DueDateTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? OriginalEstimate { get; set; }
    public int? RemainingEstimate { get; set; }
    public List<string>? AssigneeIds { get; set; }
    public List<string>? CommentIds { get; set; }
}