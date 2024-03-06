using Chrono_PM_API.Dtos.Issue;
using Chrono_PM_API.Enums;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Models;
using Chrono_PM_API.Repositories;
using Chrono_PM_API.Utilities;
using Microsoft.AspNetCore.Identity;

namespace Chrono_PM_API.Services;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _issueRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly UserManager<AppUser> _userManager;

    public IssueService(IIssueRepository issueRepository, ICommentRepository commentRepository, UserManager<AppUser> userManager)
    {
        _issueRepository = issueRepository;
        _commentRepository = commentRepository;
        _userManager = userManager;
    }

    public async Task<IEnumerable<IssueDto>> GetIssuesAsync()
    {
        var issues = await _issueRepository.GetIssuesAsync();
        var issueDtoList = IssueMapper.MapToDto(issues);
        return issueDtoList;
    }

    public async Task<IssueDto> GetIssueByIdAsync(string id)
    {
        var issue = await _issueRepository.GetIssueByIdAsync(id);
        var issueDto = IssueMapper.MapToDto(issue);
        return issueDto;
    }

    public async Task<IssueDto> CreateIssueAsync(CreateIssueDto createIssueDto, string currentUserId)
    {
        var issue = IssueMapper.MapToModel(createIssueDto, currentUserId);
        await _issueRepository.CreateIssueAsync(issue);
        var issueId = issue.Id;
        
        await UserUtility.AddEntityToUserListAsync(
            _userManager,
            currentUserId,
            issueId,
            EntityType.Issue
            );
        
        var issueDto = IssueMapper.MapToDto(issue);
        return issueDto;
    }

    public async Task<IssueDto> UpdateIssueAsync(UpdateIssueDto updateIssueDto, string id)
    {
        var existingIssue = await _issueRepository.GetIssueByIdAsync(id);
        IssueMapper.MapForUpdate(updateIssueDto, existingIssue);
        var updatedIssue = await _issueRepository.UpdateIssueAsync(existingIssue);
        return IssueMapper.MapToDto(updatedIssue);
    }

    public async Task<bool> DeleteIssueAsync(string id)
    {
        var issue = await _issueRepository.GetIssueByIdAsync(id);

        foreach (var commentId in issue.CommentIds)
        {
            await _commentRepository.DeleteCommentAsync(commentId);
        }

        var userId = issue.AuthorId;

        await UserUtility.RemoveEntityFromUserListAsync(
            _userManager,
            userId,
            id,
            EntityType.Issue
            );
        
        return await _issueRepository.DeleteIssueAsync(id);
    }
}