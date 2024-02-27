using Chrono_PM_API.Data;
using Chrono_PM_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Chrono_PM_API.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Comment>> GetCommentsAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment> GetCommentByIdAsync(string id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<bool> DeleteCommentAsync(string id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return false;
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return true;
    }
}