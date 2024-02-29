using Chrono_PM_API.Dtos.Issue;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Models;
using Chrono_PM_API.Repositories;

namespace Chrono_PM_API.Services;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _issueRepository;
    private readonly ICommentRepository _commentRepository;

    public IssueService(IIssueRepository issueRepository, ICommentRepository commentRepository)
    {
        _issueRepository = issueRepository;
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<IssueDto>> GetIssuesAsync()
    {
        var issues = await _issueRepository.GetIssuesAsync();
        var issueDtoList = IssueMapper.MapToDto(issues);
        return issueDtoList;
    }

    public async Task<Issue> GetIssueByIdAsync(int id)
    {
        return await _issueRepository.GetIssueByIdAsync(id);
    }

    public async Task<IssueDto> CreateIssueAsync(CreateIssueDto createIssueDto, string currentUserId)
    {
        var issue = IssueMapper.MapToModel(createIssueDto, currentUserId);
        await _issueRepository.CreateIssueAsync(issue);
        var issueDto = IssueMapper.MapToDto(issue);
        return issueDto;
    }

    public async Task<IssueDto> UpdateIssueAsync(UpdateIssueDto updateIssueDto, int id)
    {
        var existingIssue = await _issueRepository.GetIssueByIdAsync(id);
        if (existingIssue == null)
        {
            return null;
        }
        
        IssueMapper.MapForUpdate(updateIssueDto, existingIssue);

        var updatedIssue = await _issueRepository.UpdateIssueAsync(existingIssue);

        return IssueMapper.MapToDto(updatedIssue);
    }

    public async Task<bool> DeleteIssueAsync(int id)
    {
        var issue = await _issueRepository.GetIssueByIdAsync(id);
        if (issue == null)
        {
            return false;
        }

        foreach (var commentId in issue.CommentIds)
        {
            await _commentRepository.DeleteCommentAsync(commentId);
        }
        return await _issueRepository.DeleteIssueAsync(id);
    }
}