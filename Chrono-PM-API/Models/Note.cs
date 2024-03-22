using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chrono_PM_API.Models;

public class Note
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [Required(ErrorMessage = "Note content is required")]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }

    [Required(ErrorMessage = "ProjectId is required")]
    public string ProjectId { get; set; }

    [Required(ErrorMessage = "AuthorId is required")]
    public string AuthorId { get; set; }
}