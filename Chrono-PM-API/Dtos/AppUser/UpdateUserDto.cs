namespace Chrono_PM_API.Dtos.AppUser;

public class UpdateUserDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phonenumber { get; set; }
    public List<string> IssueIds { get; set; }
    public List<string> CommentIds { get; set; }
}