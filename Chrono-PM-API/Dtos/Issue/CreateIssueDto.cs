using System.ComponentModel.DataAnnotations;
using Chrono_PM_API.Enums;

namespace Chrono_PM_API.Dtos.Issue;

public class CreateIssueDto
{
    [MaxLength(450)]
    public string? AuthorId { get; set; }
    [MaxLength(450)]
    public string? ProjectId { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Project is required")]
    [MaxLength(50)]
    public string Project { get; set; } = string.Empty;

    public IssueType? Type { get; set; }

    public IssuePriority? Priority { get; set; }

    [MaxLength(50)]
    public string Summary { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;

    public DateTime? DueDateTime { get; set; }

    public int? OriginalEstimate { get; set; }

    public int? RemainingEstimate { get; set; }
    
    public List<string> AssigneeIds { get; set; } = new List<string>();

    public List<string> CommentIds { get; set; } = new List<string>();
}