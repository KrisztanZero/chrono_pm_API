using Microsoft.AspNetCore.Identity;

namespace Chrono_PM_API.Models;

public class AppUser : IdentityUser
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public List<string> ProjectIds { get; set; } = [];
    public List<string> IssueIds { get; set; } = [];
    public List<string> CommentIds { get; set; } = [];
}