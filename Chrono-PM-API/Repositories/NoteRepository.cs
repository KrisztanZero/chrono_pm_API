using Chrono_PM_API.Data;
using Chrono_PM_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Chrono_PM_API.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly AppDbContext _dbContext;

    public NoteRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Note>> GetNotesAsync()
    {
        return await _dbContext.Notes.ToListAsync();
    }

    public async Task<Note> GetNoteByIdAsync(string id)
    {
        return await _dbContext.Notes.FindAsync(id);
    }

    public async Task<Note> CreateNoteAsync(Note note)
    {
        await _dbContext.Notes.AddAsync(note);
        await _dbContext.SaveChangesAsync();
        return note;
    }

    public async Task<Note> UpdateNoteAsync(Note note)
    {
        _dbContext.Entry(note).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return note;
    }

    public async Task<bool> DeleteNoteAsync(string id)
    {
        var note = await _dbContext.Notes.FindAsync(id);
        if (note == null) return false;

        _dbContext.Notes.Remove(note);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}