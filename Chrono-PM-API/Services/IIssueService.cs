using Chrono_PM_API.Dtos.Issue;
using Chrono_PM_API.Models;

namespace Chrono_PM_API.Services;

public interface IIssueService
{
    Task<IEnumerable<IssueDto>> GetIssuesAsync();
    Task<Issue> GetIssueByIdAsync(string id);
    Task<IssueDto> CreateIssueAsync(CreateIssueDto createIssueDto, string currentUserId);
    Task<IssueDto> UpdateIssueAsync(UpdateIssueDto updateIssueDto, string id);
    Task<bool> DeleteIssueAsync(string id);
}