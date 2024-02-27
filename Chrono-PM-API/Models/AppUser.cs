using Microsoft.AspNetCore.Identity;

namespace Chrono_PM_API.Models;

public class AppUser : IdentityUser
{
    public ICollection<string> IssueIds { get; set; } = new List<string>();
    public ICollection<string> CommentIds { get; set; } = new List<string>();
}