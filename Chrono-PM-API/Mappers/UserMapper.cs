using Chrono_PM_API.Dtos.AppUser;
using Chrono_PM_API.Models;

namespace Chrono_PM_API.Mappers;

public static class UserMapper
{
    public static AppUserDto MapToDto(AppUser user)
    {
        return new AppUserDto()
        {
            Id = user.Id,
            Username = user.UserName,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Email = user.Email,
            Phonenumber = user.PhoneNumber,
            ProjectIds = user.ProjectIds,
            NoteIds = user.NoteIds,
            IssueIds = user.IssueIds,
            CommentIds = user.CommentIds,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            IsActive = user.IsActive,
        };
    }

    public static IEnumerable<AppUserDto> MapToDto(IEnumerable<AppUser> users)
    {
        return users.Select(MapToDto).ToList();
    }

    public static AppUser MapToModel(AppUserDto userDto)
    {
        return new AppUser()
        {
            Id = userDto.Id,
            UserName = userDto.Username,
            Firstname = userDto.Firstname,
            Lastname = userDto.Lastname,
            Email = userDto.Email,
            PhoneNumber = userDto.Phonenumber,
            ProjectIds = userDto.ProjectIds,
            NoteIds = userDto.NoteIds,
            IssueIds = userDto.IssueIds,
            CommentIds = userDto.CommentIds,
            IsActive = userDto.IsActive,
        };
    }

    public static void MapForUpdate(UpdateUserDto updateUser, AppUser user)
    {
        user.UserName = updateUser.Username ?? user.UserName;
        user.Firstname = updateUser.Firstname ?? user.Firstname;
        user.Lastname = updateUser.Lastname ?? user.Lastname;
        user.Email = updateUser.Email ?? user.Email;
        user.PhoneNumber = updateUser.PhoneNumber ?? user.PhoneNumber;
        user.ProjectIds = updateUser.ProjectIds ?? user.ProjectIds;
        user.NoteIds = updateUser.NoteIds ?? user.NoteIds;
        user.IssueIds = updateUser.IssueIds ?? user.IssueIds;
        user.CommentIds = updateUser.CommentIds ?? user.CommentIds;
        user.UpdatedAt = DateTime.Now;
    }
}