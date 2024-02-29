using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Chrono_PM_API.Utilities;

public static class UserUtilities
{
    public static string GetCurrentUserId(ControllerBase controller)
    {
        var currentUserId = controller.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(currentUserId))
        {
            throw new ArgumentException("Invalid or missing user identifier.", nameof(currentUserId));
        }
        return currentUserId;
    }
    
}