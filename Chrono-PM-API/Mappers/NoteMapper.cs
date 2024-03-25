using Chrono_PM_API.Dtos.Note;
using Chrono_PM_API.Models;

namespace Chrono_PM_API.Mappers;

public static class NoteMapper
{
    public static NoteDto MapToDto(Note note)
    {
        return new NoteDto
        {
            Id = note.Id,
            Content = note.Content,
            CreatedAt = note.CreatedAt,
            UpdatedAt = note.UpdatedAt,
            AuthorId = note.AuthorId,
            ProjectId = note.ProjectId,
        };
    }

    public static IEnumerable<NoteDto> MapToDto(IEnumerable<Note> notes)
    {
        return notes.Select(MapToDto).ToList();
    }

    public static Note MapToModel(CreateNoteDto createNoteDto, string authorId)
    {
        return new Note
        {
            Content = createNoteDto.Content,
            AuthorId = authorId,
            ProjectId = createNoteDto.ProjectId,
        };
    }

    public static void MapForUpdate(UpdateNoteDto updateNoteDto, Note existingNote)
    {
        existingNote.Content = updateNoteDto.Content ?? existingNote.Content;
        existingNote.UpdatedAt = DateTime.Now;
    }
}