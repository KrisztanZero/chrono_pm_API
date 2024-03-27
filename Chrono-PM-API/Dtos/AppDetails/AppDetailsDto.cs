using System.ComponentModel.DataAnnotations;

namespace Chrono_PM_API.Dtos.AppDetails;

public class AppDetailsDto
{
    public string Id { get; init; }

    [MaxLength(50)]
    public string WelcomeMessage { get; set; } = string.Empty;

    [MaxLength(450)] public string Introduction { get; set; } = string.Empty;
    [MaxLength(50)] public string Version { get; set; } = string.Empty;
    [MaxLength(100)] public List<string> Developers { get; set; } = new List<string>();
    public string CopyRights { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}