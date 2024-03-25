using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Chrono_PM_API.Models;

public class AppUser : IdentityUser
{
    [MaxLength(50)] public string Firstname { get; set; } = string.Empty;
    [MaxLength(50)] public string Lastname { get; set; } = string.Empty;
    public List<string> ProjectIds { get; set; } = new List<string>();
    public List<string> NoteIds { get; set; } = new List<string>();
    public List<string> IssueIds { get; set; } = new List<string>();
    public List<string> CommentIds { get; set; } = new List<string>();
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}