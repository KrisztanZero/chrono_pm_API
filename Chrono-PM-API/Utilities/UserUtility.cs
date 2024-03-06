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
    }
}