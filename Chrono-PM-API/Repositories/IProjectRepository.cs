using Chrono_PM_API.Models;

namespace Chrono_PM_API.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetProjectAsync();
    Task<Project> GetProjectByIdAsync(string id);
    Task<Project> CreateProjectAsync(Project project);
    Task<Project> UpdateProjectAsync(Project project);
    Task<bool> DeleteProjectAsync(string id);
}