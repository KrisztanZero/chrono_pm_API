namespace Chrono_PM_API.Dtos.Project;

public class ProjectDto
{
    public string Id { get; set; }
    public string AuthorId { get; set; }
    public List<string> NoteIds { get; set; }
    public string ProjectName { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public DateTime DueDateTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? OriginalEstimate { get; set; }
    public int? RemainingEstimate { get; set; }
    public List<string> AssigneeIds { get; set; }
    public List<string> IssueIds { get; set; }
}