namespace Chrono_PM_API.Dtos.Note;

public class UpdateNoteDto
{
    public string Content { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}