using Chrono_PM_API.Dtos.Issue;

namespace Chrono_PM_API.Services;

public interface IIssueService
{
    Task<IEnumerable<IssueDto>> GetIssuesAsync();
    Task<IssueDto> GetIssueByIdAsync(string id);
    Task<IssueDto> CreateIssueAsync(CreateIssueDto createIssueDto, string currentUserId);
    Task<IssueDto> UpdateIssueAsync(UpdateIssueDto updateIssueDto, string id);
    Task<bool> DeleteIssueAsync(string id);
}