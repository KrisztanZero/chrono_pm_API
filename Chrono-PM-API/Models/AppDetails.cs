using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chrono_PM_API.Models;

public class AppDetails
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }

    [MaxLength(50)]
    public string WelcomeMessage { get; set; } = string.Empty;

    [MaxLength(1500)] public string Introduction { get; set; } = string.Empty;
    [MaxLength(50)] public string Version { get; set; } = string.Empty;
    [MaxLength(100)]public List<string> Developers { get; init; } = new List<string>();
    public string CopyRights { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    
}