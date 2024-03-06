using Chrono_PM_API.Dtos.Comment;
using Chrono_PM_API.Enums;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Models;
using Chrono_PM_API.Repositories;
using Chrono_PM_API.Utilities;
using Microsoft.AspNetCore.Identity;

namespace Chrono_PM_API.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IIssueRepository _issueRepository;
    private readonly UserManager<AppUser> _userManager;

    public CommentService(ICommentRepository commentRepository, IIssueRepository issueRepository, UserManager<AppUser> userManager)
    {
        _commentRepository = commentRepository;
        _issueRepository = issueRepository;
        _userManager = userManager;
    }

    public async Task<IEnumerable<CommentDto>> GetCommentsAsync()
    {
        var comment = await _commentRepository.GetCommentsAsync();
        var commentDtoList = CommentMapper.MapToDto(comment);
        return commentDtoList;
    }

    public async Task<CommentDto> GetCommentByIdAsync(string id)
    {
        var comment = await _commentRepository.GetCommentByIdAsync(id);
        var commentDto = CommentMapper.MapToDto(comment);
        return commentDto;
    }

    public async Task<CommentDto> CreateCommentAsync(CreateCommentDto createCommentDto, string currentUserId)
    {
        var comment = CommentMapper.MapToModel(createCommentDto, currentUserId);
        await _commentRepository.CreateCommentAsync(comment);
        var commentId = comment.Id;
        
        var existingIssue = await _issueRepository.GetIssueByIdAsync(createCommentDto.IssueId);
        existingIssue.CommentIds.Add(commentId);
        await _issueRepository.UpdateIssueAsync(existingIssue);
        
        await UserUtility.AddEntityToUserListAsync(
            _userManager,
            currentUserId,
            commentId,
            EntityType.Comment
            );
        
        var commentDto = CommentMapper.MapToDto(comment);
        return commentDto;
    }

    public async Task<bool> DeleteCommentAsync(string id)
    {
        try
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);

            await _commentRepository.DeleteCommentAsync(id);

            var issue = await _issueRepository.GetIssueByIdAsync(comment.IssueId);

            issue.CommentIds.Remove(id);

            await _issueRepository.UpdateIssueAsync(issue);

            var userId = comment.AuthorId;
            await UserUtility.RemoveEntityFromUserListAsync(
                _userManager,
                userId,
                id,
                EntityType.Comment
                );

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}