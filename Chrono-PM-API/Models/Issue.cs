using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chrono_PM_API.Enums;

namespace Chrono_PM_API.Models;

public class Issue
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(450)]
    public string? Id { get; init; }

    [MaxLength(450)]
    [Required(ErrorMessage = "AuthorId is required")]
    public string? AuthorId { get; init; }

    [MaxLength(450)]
    [Required(ErrorMessage = "ProjectId is required")]
    public string? ProjectId { get; init; }

    [MaxLength(50)] public string Title { get; set; } = string.Empty;
    public IssueType Type { get; set; }
    public IssuePriority Priority { get; set; }
    [MaxLength(50)] public string Summary { get; set; } = string.Empty;
    [MaxLength(250)] public string Description { get; set; } = string.Empty;
    public DateTime DueDateTime { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "OriginalEstimate must be non-negative.")]
    public int? OriginalEstimate { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "RemainingEstimate must be non-negative.")]
    public int? RemainingEstimate { get; set; }

    public List<string> AssigneeIds { get; set; } = new List<string>();
    public List<string> CommentIds { get; set; } = new List<string>();
}