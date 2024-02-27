using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chrono_PM_API.Enums;

namespace Chrono_PM_API.Models;

public class Issue
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; } = string.Empty;
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Project { get; set; } = string.Empty;
    public  IssueType Type { get; set; } = IssueType.Task;
    public IssuePriority Priority { get; set; } = IssuePriority.Medium;
    [MaxLength(50)]
    public string Summary { get; set; } = string.Empty;
    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;
    public DateTime DueDateTime { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime OriginalEstimate { get; set; }
    public DateTime RemainingEstimate { get; set; }

    [Required(ErrorMessage = "AuthorId is required")]
    public string AuthorId { get; init; } = string.Empty;

    public ICollection<int> AssigneeIds { get; set; } = new List<int>();
    public ICollection<int> CommentIds { get; set; } = new List<int>();
}