using Chrono_PM_API.Dtos.Issue;
using Chrono_PM_API.Models;

namespace Chrono_PM_API.Services;

public interface IIssueService
{
    Task<IEnumerable<Issue>> GetIssuesAsync();
    Task<Issue> GetIssueByIdAsync(int id);
    Task<IssueDto> CreateIssueAsync(CreateIssueDto createIssueDto, string currentUserId);
    Task<IssueDto> UpdateIssueAsync(UpdateIssueDto updateIssueDto, int id);
    Task<bool> DeleteIssueAsync(int id);
}