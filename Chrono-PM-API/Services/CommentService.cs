using Chrono_PM_API.Models;
using Chrono_PM_API.Repositories;

namespace Chrono_PM_API.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<Comment>> GetCommentsAsync()
    {
        return await _commentRepository.GetCommentsAsync();
    }

    public async Task<Comment> GetCommentByIdAsync(string id)
    {
        return await _commentRepository.GetCommentByIdAsync(id);
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        return await _commentRepository.CreateCommentAsync(comment);
    }

    public async Task<bool> DeleteCommentAsync(string id)
    {
        return await _commentRepository.DeleteCommentAsync(id);
    }
}