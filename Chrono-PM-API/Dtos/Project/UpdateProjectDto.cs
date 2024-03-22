using System.ComponentModel.DataAnnotations;

namespace Chrono_PM_API.Dtos.Project;

public class UpdateProjectDto
{
    [MaxLength(50)]
    public string? ProjectName { get; set; }
    [MaxLength(50)]
    public string? Summary { get; set; }
    [MaxLength(250)]
    public string? Description { get; set; }
    public DateTime? DueDateTime { get; set; }
    public DateTime UpdatedAt { get; init; } = DateTime.Now;
    [Range(0, int.MaxValue, ErrorMessage = "OriginalEstimate must be non-negative.")]
    public int? OriginalEstimate { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "RemainingEstimate must be non-negative.")]
    public int? RemainingEstimate { get; set; }

    public List<string> AssigneeIds { get; set; }
    public List<string> IssueIds { get; set; }
    public List<string> NoteIds { get; set; }
}