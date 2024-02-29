using System.ComponentModel.DataAnnotations;

namespace Chrono_PM_API.Dtos.Comment;

public record CommentDto()
{
    public string Id { get; init; }

    [Required(ErrorMessage = "Summary is required")]
    [MaxLength(50, ErrorMessage = "Summary can be up to 50 characters long")]
    public string Summary { get; init; }

    [Required(ErrorMessage = "Content is required")]
    [MaxLength(250, ErrorMessage = "Content can be up to 250 characters long")]
    public string Content { get; init; }

    public DateTime CreatedAt { get; init; }

    [Required(ErrorMessage = "AuthorId is required")]
    public string AuthorId { get; init; }

    [Required(ErrorMessage = "IssueId is required")]
    public string IssueId { get; init; }
}