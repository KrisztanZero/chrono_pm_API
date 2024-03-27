using System.ComponentModel.DataAnnotations;

namespace Chrono_PM_API.Dtos.AppDetails;

public class UpdateAppDetailsDto
{
    [MaxLength(50)]
    public string? WelcomeMessage { get; set; }
    [MaxLength(1500)] public string? Introduction { get; set; }
    [MaxLength(50)] public string? Version { get; set; }
    [MaxLength(100)]public List<string>? Developers { get; set; }
    public string? CopyRights { get; set; }
}