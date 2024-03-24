namespace Chrono_PM_API.Dtos.AppUser;

public class UpdateUserDto
{
    public string? Username { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public List<string>? ProjectIds { get; set; }
    public List<string>? NoteIds { get; set; }
    public List<string>? IssueIds { get; set; }
    public List<string>? CommentIds { get; set; }
}