namespace Chrono_PM_API.Dtos.AppUser;

public class AppUserDto
{
    public string? Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Phonenumber { get; set; }
    public List<string>? ProjectIds { get; set; }
    public List<string>? NoteIds { get; set; }
    public List<string>? IssueIds { get; set; }
    public List<string>? CommentIds { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}