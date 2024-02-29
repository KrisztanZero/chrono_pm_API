using System.ComponentModel.DataAnnotations;

namespace Chrono_PM_API.Dtos.Comment;

public record CreateCommentDto()
{
    [Required(ErrorMessage = "Summary is required")]
    [MaxLength(50, ErrorMessage = "Summary must be at most 50 characters long")]
    public string Summary { get; init; }

    [Required(ErrorMessage = "Content is required")]
    [MaxLength(250, ErrorMessage = "Content must be at most 250 characters long")]
    public string Content { get; init; }

    [Required(ErrorMessage = "IssueId is required")]
    public string IssueId { get; init; }
}