using Chrono_PM_API.Dtos.Project;
using Chrono_PM_API.Enums;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Models;
using Chrono_PM_API.Repositories;
using Chrono_PM_API.Utilities;
using Microsoft.AspNetCore.Identity;

namespace Chrono_PM_API.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly INoteRepository _noteRepository;
    private readonly IIssueRepository _issueRepository;
    private readonly UserManager<AppUser> _userManager;

    public ProjectService(IProjectRepository projectRepository, INoteRepository noteRepository,
        UserManager<AppUser> userManager, IIssueRepository issueRepository)
    {
        _projectRepository = projectRepository;
        _noteRepository = noteRepository;
        _userManager = userManager;
        _issueRepository = issueRepository;
    }

    public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
    {
        var projects = await _projectRepository.GetProjectsAsync();
        var projectDtoList = ProjectMapper.MapToDto(projects);
        return projectDtoList;
    }

    public async Task<ProjectDto> GetProjectByIdAsync(string id)
    {
        var project = await _projectRepository.GetProjectByIdAsync(id);
        var projectDto = ProjectMapper.MapToDto(project);
        return projectDto;
    }

    public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto createProjectDto, string currentUserId)
    {
        var project = ProjectMapper.MapToModel(createProjectDto, currentUserId);
        await _projectRepository.CreateProjectAsync(project);
        var projectId = project.Id;

        await UserUtility.AddEntityToUserListAsync(
            _userManager,
            currentUserId,
            projectId,
            EntityType.Project
        );

        var projectDto = ProjectMapper.MapToDto(project);
        return projectDto;
    }

    public async Task<ProjectDto> UpdateProjectAsync(UpdateProjectDto updateProjectDto, string id)
    {
        var existingProject = await _projectRepository.GetProjectByIdAsync(id);
        ProjectMapper.MapForUpdate(updateProjectDto, existingProject);
        var updateProject = await _projectRepository.UpdateProjectAsync(existingProject);

        foreach (var assigneeId in existingProject.AssigneeIds)
        {
            await UserUtility.AddEntityToUserListAsync(_userManager, assigneeId, existingProject.Id,
                EntityType.Project);
        }

        return ProjectMapper.MapToDto(updateProject);
    }

    public async Task<bool> DeleteProjectAsync(string id)
    {
        var project = await _projectRepository.GetProjectByIdAsync(id);
        foreach (var issueId in project.IssueIds)
        {
            await _issueRepository.DeleteIssueAsync(issueId);
        }

        foreach (var noteId in project.NoteIds)
        {
            await _noteRepository.DeleteNoteAsync(noteId);
        }

        var userId = project.AuthorId;

        await UserUtility.RemoveEntityFromUserListAsync(
            _userManager,
            userId,
            id,
            EntityType.Project
        );

        return await _projectRepository.DeleteProjectAsync(id);
    }
}