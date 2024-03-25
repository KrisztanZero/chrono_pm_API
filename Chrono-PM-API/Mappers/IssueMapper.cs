﻿using Chrono_PM_API.Dtos.Issue;
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
            ProjectId = issue.ProjectId,
            Type = issue.Type,
            Priority = issue.Priority,
            Summary = issue.Summary,
            Description = issue.Description,
            DueDateTime = issue.DueDateTime,
            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
            OriginalEstimate = issue.OriginalEstimate,
            RemainingEstimate = issue.RemainingEstimate,
            AuthorId = issue.AuthorId,
            AssigneeIds = issue.AssigneeIds,
            CommentIds = issue.CommentIds
        };
    }

    public static IEnumerable<IssueDto> MapToDto(IEnumerable<Issue> issues)
    {
        return issues.Select(MapToDto).ToList();
    }

    public static Issue MapToModel(CreateIssueDto createDto, string authorId)
    {
        return new Issue
        {
            Title = createDto.Title,
            AuthorId = authorId,
            ProjectId = createDto.ProjectId,
            Type = createDto.Type,
            Priority = createDto.Priority,
            Summary = createDto.Summary,
            Description = createDto.Description,
            DueDateTime = createDto.DueDateTime,
            OriginalEstimate = createDto.OriginalEstimate ?? default,
            RemainingEstimate = createDto.RemainingEstimate ?? default,
            AssigneeIds = createDto.AssigneeIds,
            CommentIds = createDto.CommentIds
        };
    }

    public static void MapForUpdate(UpdateIssueDto updateDto, Issue existingIssue)
    {
        existingIssue.Title = updateDto.Title ?? existingIssue.Title;
        existingIssue.Type = updateDto.Type ?? existingIssue.Type;
        existingIssue.Priority = updateDto.Priority ?? existingIssue.Priority;
        existingIssue.Summary = updateDto.Summary ?? existingIssue.Summary;
        existingIssue.Description = updateDto.Description ?? existingIssue.Description;
        existingIssue.DueDateTime = updateDto.DueDateTime ?? existingIssue.DueDateTime;
        existingIssue.OriginalEstimate = updateDto.OriginalEstimate ?? existingIssue.OriginalEstimate;
        existingIssue.RemainingEstimate = updateDto.RemainingEstimate ?? existingIssue.RemainingEstimate;
        if (updateDto.AssigneeIds != null && updateDto.AssigneeIds.Any())
        {
            existingIssue.AssigneeIds.AddRange(updateDto.AssigneeIds.Except(existingIssue.AssigneeIds));
        }

        if (updateDto.CommentIds != null && updateDto.CommentIds.Any())
        {
            existingIssue.CommentIds.AddRange(updateDto.CommentIds.Except(existingIssue.CommentIds));
        }

        existingIssue.UpdatedAt = DateTime.Now;
    }
}