using Chrono_PM_API.Dtos.Project;
using Chrono_PM_API.Models;

namespace Chrono_PM_API.Mappers;

public static class ProjectMapper
{
    public static ProjectDto MapToDto(Project project)
    {
        return new ProjectDto()
        {
            Id = project.Id,
            ProjectName = project.ProjectName,
            Summary = project.Summary,
            Description = project.Description,
            DueDateTime = project.DueDateTime,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt,
            OriginalEstimate = project.OriginalEstimate,
            RemainingEstimate = project.RemainingEstimate,
            AuthorId = project.AuthorId,
            AssigneeIds = project.AssigneeIds,
            IssueIds = project.IssueIds,
            NoteIds = project.NoteIds
        };
    }

    public static IEnumerable<ProjectDto> MapToDto(IEnumerable<Project> projects)
    {
        return projects.Select(project => MapToDto(project)).ToList();
    }

    public static Project MapToModel(CreateProjectDto createProjectDto, string authorId)
    {
        return new Project()
        {
            ProjectName = createProjectDto.ProjectName,
            Summary = createProjectDto.Summary,
            Description = createProjectDto.Description,
            DueDateTime = createProjectDto.DueDateTime,
            CreatedAt = createProjectDto.CreatedAt,
            OriginalEstimate = createProjectDto.OriginalEstimate,
            RemainingEstimate = createProjectDto.RemainingEstimate,
            AuthorId = authorId,
            AssigneeIds = createProjectDto.AssigneeIds,
            IssueIds = createProjectDto.IssueIds,
            NoteIds = createProjectDto.NoteIds
        };
    }

    public static void MapForUpdate(UpdateProjectDto updateProjectDto, Project project)
    {
        project.ProjectName = updateProjectDto.ProjectName ?? project.ProjectName;
        project.Summary = updateProjectDto.Summary ?? project.Summary;
        project.Description = updateProjectDto.Description ?? project.Description;
        project.DueDateTime = updateProjectDto.DueDateTime ?? project.DueDateTime;
        project.OriginalEstimate = updateProjectDto.OriginalEstimate ?? project.OriginalEstimate;
        project.RemainingEstimate = updateProjectDto.RemainingEstimate ?? project.RemainingEstimate;
    }
}