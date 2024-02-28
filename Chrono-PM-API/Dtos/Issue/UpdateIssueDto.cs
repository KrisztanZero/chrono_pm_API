using System.ComponentModel.DataAnnotations;
using Chrono_PM_API.Enums;

namespace Chrono_PM_API.Dtos.Issue;

public class UpdateIssueDto
{
    [MaxLength(50)]
    public string Title { get; set; }

    [MaxLength(50)]
    public string Project { get; set; }

    public IssueType Type { get; set; }
    public IssuePriority Priority { get; set; }

    [MaxLength(50)]
    public string Summary { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    public DateTime DueDateTime { get; set; }
    public int OriginalEstimate { get; set; }
    public int RemainingEstimate { get; set; }

    public string AuthorId { get; set; }

    public List<string> AssigneeIds { get; set; }
    public List<int> CommentIds { get; set; }
}