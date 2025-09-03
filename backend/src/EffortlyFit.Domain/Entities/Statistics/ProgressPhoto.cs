using System.ComponentModel.DataAnnotations;

namespace EffortlyFit.Domain.Entities.Statistics;

public class ProgressPhoto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    [StringLength(500)]
    public string FilePath { get; set; } = string.Empty;
    
    [StringLength(20)]
    public string PhotoType { get; set; } = "Progress"; // Progress, Before, After
    
    [StringLength(50)]
    public string? BodyPart { get; set; } // Front, Side, Back, Arms, Legs, etc.
    
    public DateTime TakenAt { get; set; }
    
    [StringLength(500)]
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public virtual User User { get; set; } = null!;
}
