using Chrono_PM_API.Models;
using Chrono_PM_API.Repositories;

namespace Chrono_PM_API.Services;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _issueRepository;

    public IssueService(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task<IEnumerable<Issue>> GetIssuesAsync()
    {
        return await _issueRepository.GetIssuesAsync();
    }

    public async Task<Issue> GetIssueByIdAsync(string id)
    {
        return await _issueRepository.GetIssueByIdAsync(id);
    }

    public async Task<Issue> CreateIssueAsync(Issue issue)
    {
        return await _issueRepository.CreateIssueAsync(issue);
    }

    public async Task<bool> DeleteIssueAsync(string id)
    {
        return await _issueRepository.DeleteIssueAsync(id);
    }
}