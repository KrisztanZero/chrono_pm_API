using System.ComponentModel.DataAnnotations;

namespace Chrono_PM_API.Dtos.AppUser;

public class AppUserDto
{
    public string Id { get; set; }
    [MaxLength(50)] public string Firstname { get; set; }
    [MaxLength(50)] public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phonenumber { get; set; }
    [MaxLength(450)] public List<string> ProjectIds { get; set; }
    [MaxLength(450)] public List<string> NoteIds { get; set; }
    [MaxLength(450)] public List<string> IssueIds { get; set; }
    [MaxLength(450)] public List<string> CommentIds { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}