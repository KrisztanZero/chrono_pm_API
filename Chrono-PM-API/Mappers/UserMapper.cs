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
            Email = user.Email,
            Phonenumber = user.PhoneNumber,
            IssueIds = user.IssueIds,
            CommentIds = user.CommentIds
        };
    }

    public static IEnumerable<AppUserDto> MapToDto(IEnumerable<AppUser> users)
    {
        return users.Select(user => MapToDto(user)).ToList();
    }

    public static AppUser MapToModel(AppUserDto userDto)
    {
        return new AppUser()
        {
            Id = userDto.Id,
            UserName = userDto.Username,
            Email = userDto.Email,
            PhoneNumber = userDto.Phonenumber,
            IssueIds = userDto.IssueIds,
            CommentIds = userDto.CommentIds
        };
    }

    public static void MapForUpdate(UpdateUserDto updateUser, AppUser user)
    {
        if (updateUser.Username != null)
        {
            user.UserName = updateUser.Username;
        }

        if (updateUser.Email != null)
        {
            user.Email = updateUser.Email;
        }

        if (updateUser.Phonenumber != null)
        {
            user.PhoneNumber = updateUser.Phonenumber;
        }

        if (updateUser.IssueIds != null)
        {
            user.IssueIds = updateUser.IssueIds;
        }

        if (updateUser.CommentIds != null)
        {
            user.CommentIds = updateUser.CommentIds;
        }
    }
}