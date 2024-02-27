using Microsoft.AspNetCore.Identity;

namespace Chrono_PM_API.Models;

public class AppUser : IdentityUser
{
    public List<string> IssueIds { get; set; } = new List<string>();
    public List<string> CommentIds { get; set; } = new List<string>();
}