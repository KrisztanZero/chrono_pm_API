using System.ComponentModel.DataAnnotations;

namespace Chrono_PM_API.Dtos.AppDetails;

public class CreateAppDetailsDto
{
    [MaxLength(50)]
    public string WelcomeMessage { get; set; }
    [MaxLength(1500)] public string Introduction { get; set; }
    [MaxLength(50)] public string Version { get; set; }
    [MaxLength(100)] public List<string> Developers { get; set; }
    public string CopyRights { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}