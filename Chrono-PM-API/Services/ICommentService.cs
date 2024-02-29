using Chrono_PM_API.Dtos.Comment;

namespace Chrono_PM_API.Services;

public interface ICommentService
{
    Task<IEnumerable<CommentDto>> GetCommentsAsync();
    Task<CommentDto> GetCommentByIdAsync(string id);
    Task<CommentDto> CreateCommentAsync(CreateCommentDto comment, string authorId);
    Task<bool> DeleteCommentAsync(string id);
}