using Chrono_PM_API.Models;

namespace Chrono_PM_API.Repositories;

public interface IIssueRepository
{
    Task<IEnumerable<Issue>> GetIssuesAsync();
    Task<Issue> GetIssueByIdAsync(int id);
    Task<Issue> CreateIssueAsync(Issue issue);
    Task<Issue> UpdateIssueAsync(Issue issue);
    Task<bool> DeleteIssueAsync(int id);
}