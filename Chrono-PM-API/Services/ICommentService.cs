using Chrono_PM_API.Models;

namespace Chrono_PM_API.Services;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetCommentsAsync();
    Task<Comment> GetCommentByIdAsync(string id);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<bool> DeleteCommentAsync(string id);
}