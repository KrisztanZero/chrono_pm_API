using Chrono_PM_API.Dtos.AppUser;
using Chrono_PM_API.Enums;
using Chrono_PM_API.Mappers;
using Chrono_PM_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chrono_PM_API.Utilities
{
    public static class UserUtility
    {
        public static async Task<string> GetCurrentUserIdAsync(UserManager<AppUser> userManager, ControllerBase controller)
        {
            var user = await userManager.GetUserAsync(controller.User);
            if (user == null)
            {
                throw new ArgumentException("Invalid or missing user.");
            }

            return user.Id;
        }
        
        public static async Task<AppUserDto> AddEntityToUserListAsync(UserManager<AppUser> userManager, string userId, string entityId, EntityType entityType)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException($"User not found with id: {userId}");
            }

            switch (entityType)
            {
                case EntityType.Issue:
                    user.IssueIds.Add(entityId);
                    break;
                case EntityType.Comment:
                    user.CommentIds.Add(entityId);
                    break;
                default:
                    throw new ArgumentException($"Invalid entity type: {entityType}");
            }

            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to update user: {result.Errors}");
            }

            return UserMapper.MapToDto(user);
        }

        public static async Task<bool> RemoveEntityFromUserListAsync(UserManager<AppUser> userManager, string userId, string entityId, EntityType entityType)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException($"User not found with id: {userId}");
            }

            switch (entityType)
            {
                case EntityType.Issue:
                    user.IssueIds.Remove(entityId);
                    break;
                case EntityType.Comment:
                    user.CommentIds.Remove(entityId);
                    break;
                default:
                    throw new ArgumentException($"Invalid entity type: {entityType}");
            }

            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to update user: {result.Errors}");
            }

            return true;
        }
    }
}