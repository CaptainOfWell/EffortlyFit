using System.ComponentModel.DataAnnotations;

namespace EffortlyFit.Domain.Entities.Statistics;

public class BodyWeight
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid UserId { get; set; }
    
    public double Weight { get; set; } // in kg
    
    public DateTime MeasuredAt { get; set; }
    
    [StringLength(500)]
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public virtual User User { get; set; } = null!;
}
