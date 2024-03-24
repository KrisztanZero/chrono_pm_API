using Chrono_PM_API.Dtos.Project;

namespace Chrono_PM_API.Services;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetProjectsAsync();
    Task<ProjectDto> GetProjectByIdAsync(string id);
    Task<ProjectDto> CreateProjectAsync(CreateProjectDto createProjectDto, string currentUserId);
    Task<ProjectDto> UpdateProjectAsync(UpdateProjectDto updateProjectDto, string id);
    Task<bool> DeleteProjectAsync(string id);
}