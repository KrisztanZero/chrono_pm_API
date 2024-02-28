using Chrono_PM_API.Dtos.Issue;
using Chrono_PM_API.Models;

namespace Chrono_PM_API.Mappers;

public static class IssueMapper
{
    public static IssueDto MapToDto(Issue issue)
    {
        return new IssueDto
        {
            Id = issue.Id,
            Title = issue.Title,
            Project = issue.Project,
            Type = issue.Type,
            Priority = issue.Priority,
            Summary = issue.Summary,
            Description = issue.Description,
            DueDateTime = issue.DueDateTime,
            CreatedAt = issue.CreatedAt,
            OriginalEstimate = issue.OriginalEstimate,
            RemainingEstimate = issue.RemainingEstimate,
            AuthorId = issue.AuthorId,
            AssigneeIds = issue.AssigneeIds,
            CommentIds = issue.CommentIds
        };
    }
    
    public static IEnumerable<IssueDto> MapToDto(IEnumerable<Issue> issues)
    {
        return issues.Select(issue => MapToDto(issue)).ToList();
    }

    public static Issue MapToModel(CreateIssueDto createDto, string authorId)
    {
        return new Issue
        {
            Title = createDto.Title,
            Project = createDto.Project,
            Type = createDto.Type ?? default,
            Priority = createDto.Priority ?? default,
            Summary = createDto.Summary,
            Description = createDto.Description,
            DueDateTime = createDto.DueDateTime ?? default,
            OriginalEstimate = createDto.OriginalEstimate ?? default,
            RemainingEstimate = createDto.RemainingEstimate ?? default,
            AuthorId = authorId,
            AssigneeIds = createDto.AssigneeIds,
            CommentIds = createDto.CommentIds
        };
    }

    public static void MapForUpdate(UpdateIssueDto updateDto, Issue existingIssue)
    {
        if (updateDto.Title != null)
            existingIssue.Title = updateDto.Title;

        if (updateDto.Project != null)
            existingIssue.Project = updateDto.Project;

        if (updateDto.Type != default)
            existingIssue.Type = updateDto.Type;

        if (updateDto.Priority != default)
            existingIssue.Priority = updateDto.Priority;

        if (updateDto.Summary != null)
            existingIssue.Summary = updateDto.Summary;

        if (updateDto.Description != null)
            existingIssue.Description = updateDto.Description;

        if (updateDto.DueDateTime != default)
            existingIssue.DueDateTime = updateDto.DueDateTime;

        if (updateDto.OriginalEstimate != default)
            existingIssue.OriginalEstimate = updateDto.OriginalEstimate;

        if (updateDto.RemainingEstimate != default)
            existingIssue.RemainingEstimate = updateDto.RemainingEstimate;
        
        if (updateDto.AssigneeIds != null)
            existingIssue.AssigneeIds = updateDto.AssigneeIds;

        if (updateDto.CommentIds != null)
            existingIssue.CommentIds = updateDto.CommentIds;
    }
}