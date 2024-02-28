using Chrono_PM_API.Models;

namespace Chrono_PM_API.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetCommentsAsync();
    Task<Comment> GetCommentByIdAsync(int id);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<bool> DeleteCommentAsync(int id);
}