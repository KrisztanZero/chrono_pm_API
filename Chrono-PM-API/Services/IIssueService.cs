using Chrono_PM_API.Models;

namespace Chrono_PM_API.Services;

public interface IIssueService
{
    Task<IEnumerable<Issue>> GetIssuesAsync();
    Task<Issue> GetIssueByIdAsync(string id);
    Task<Issue> CreateIssueAsync(Issue issue);
    Task<bool> DeleteIssueAsync(string id);
}