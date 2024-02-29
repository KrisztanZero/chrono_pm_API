using Chrono_PM_API.Dtos.Comment;
using Chrono_PM_API.Models;

namespace Chrono_PM_API.Mappers;

public static class CommentMapper
{
    public static CommentDto MapToDto(Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Summary = comment.Summary,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            AuthorId = comment.AuthorId,
            IssueId = comment.IssueId
        };
    }

    public static IEnumerable<CommentDto> MapToDto(IEnumerable<Comment> comments)
    {
        return comments.Select(MapToDto).ToList();
    }

    public static Comment MapToModel(CreateCommentDto createCommentDto, string authorId)
    {
        return new Comment
        {
            Summary = createCommentDto.Summary,
            Content = createCommentDto.Content,
            AuthorId = authorId,
            IssueId = createCommentDto.IssueId
        };
    }
}