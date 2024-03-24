using Chrono_PM_API.Models;

namespace Chrono_PM_API.Repositories;

public interface INoteRepository
{
    Task<IEnumerable<Note>> GetNotesAsync();
    Task<Note> GetNoteByIdAsync(string id);
    Task<Note> CreateNoteAsync(Note note);
    Task<Note> UpdateNoteAsync(Note note);
    Task<bool> DeleteNoteAsync(string id);
}