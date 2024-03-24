using Chrono_PM_API.Dtos.Note;
using Chrono_PM_API.Enums;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Models;
using Chrono_PM_API.Repositories;
using Chrono_PM_API.Utilities;
using Microsoft.AspNetCore.Identity;

namespace Chrono_PM_API.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly UserManager<AppUser> _userManager;

    public NoteService(INoteRepository noteRepository, IProjectRepository projectRepository, UserManager<AppUser> userManager)
    {
        _noteRepository = noteRepository;
        _projectRepository = projectRepository;
        _userManager = userManager;
    }

    public async Task<IEnumerable<NoteDto>> GetNotesAsync()
    {
        var noteList = await _noteRepository.GetNotesAsync();
        var noteDtoList = NoteMapper.MapToDto(noteList);
        return noteDtoList;
    }

    public async Task<NoteDto> GetNoteByIdAsync(string id)
    {
        var note = await _noteRepository.GetNoteByIdAsync(id);
        var noteDto = NoteMapper.MapToDto(note);
        return noteDto;
    }

    public async Task<NoteDto> CreateNoteAsync(CreateNoteDto createNoteDto, string currentUserId)
    {
        var note = NoteMapper.MapToModel(createNoteDto, currentUserId);
        await _noteRepository.CreateNoteAsync(note);
        var noteId = note.Id;

        var existingProject = await _projectRepository.GetProjectByIdAsync(createNoteDto.ProjectId);
        existingProject.NoteIds.Add(noteId);
        await _projectRepository.UpdateProjectAsync(existingProject);

        await UserUtility.AddEntityToUserListAsync(
            _userManager,
            currentUserId,
            noteId,
            EntityType.Note
        );

        var noteDto = NoteMapper.MapToDto(note);
        return noteDto;
    }

    public async Task<NoteDto> UpdateNoteAsync(UpdateNoteDto updateNoteDto, string id)
    {
        var exitingNote = await _noteRepository.GetNoteByIdAsync(id);
        NoteMapper.MapForUpdate(updateNoteDto, exitingNote);
        var updatedNote = await _noteRepository.UpdateNoteAsync(exitingNote);
        return NoteMapper.MapToDto(updatedNote);
    }

    public async Task<bool> DeleteNoteAsync(string id)
    {
        try
        {
            var note = await _noteRepository.GetNoteByIdAsync(id);
            await _noteRepository.DeleteNoteAsync(id);
            var project = await _projectRepository.GetProjectByIdAsync(note.ProjectId);
            project.NoteIds.Remove(id);

            var userId = note.AuthorId;
            await UserUtility.RemoveEntityFromUserListAsync(
                _userManager,
                userId,
                id,
                EntityType.Note
            );

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
        
    }
}