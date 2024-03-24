using Chrono_PM_API.Dtos.Note;

namespace Chrono_PM_API.Services;

public interface INoteService
{
    Task<IEnumerable<NoteDto>> GetNotesAsync();
    Task<NoteDto> GetNoteByIdAsync(string id);
    Task<NoteDto> CreateNoteAsync(CreateNoteDto createNoteDto, string currentUserId);
    Task<NoteDto> UpdateNoteAsync(UpdateNoteDto updateNoteDto, string id);
    Task<bool> DeleteNoteAsync(string id);
}