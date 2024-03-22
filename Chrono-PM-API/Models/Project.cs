using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chrono_PM_API.Models;

public class Project
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }
    [MaxLength(50)]
    [Required(ErrorMessage = "ProjectName is required")]
    public string ProjectName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Summary { get; set; } = string.Empty;
    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;
    public DateTime DueDateTime { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Range(0, int.MaxValue, ErrorMessage = "OriginalEstimate must be non-negative.")]
    public int OriginalEstimate { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "RemainingEstimate must be non-negative.")]
    public int RemainingEstimate { get; set; }

    [Required(ErrorMessage = "AuthorId is required")]
    public string AuthorId { get; init; }

    public List<string> AssigneeIds { get; set; } = new List<string>();
    public List<string> IssueIds { get; set; } = new List<string>();
    public List<string> NoteIds { get; set; } = new List<string>();
}