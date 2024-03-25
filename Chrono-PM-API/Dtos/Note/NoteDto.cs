namespace Chrono_PM_API.Dtos.Note;

public class NoteDto
{
    public string Id { get; set; }

    public string Content { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string ProjectId { get; set; }

    public string AuthorId { get; set; }
}