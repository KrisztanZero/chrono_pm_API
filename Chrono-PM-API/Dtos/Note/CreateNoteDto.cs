using System.ComponentModel.DataAnnotations;

namespace Chrono_PM_API.Dtos.Note;

public class CreateNoteDto
{
    [Required(ErrorMessage = "Note content is required")]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }

    [Required(ErrorMessage = "ProjectId is required")]
    public string ProjectId { get; set; }

    [Required(ErrorMessage = "AuthorId is required")]
    public string AuthorId { get; set; }
}