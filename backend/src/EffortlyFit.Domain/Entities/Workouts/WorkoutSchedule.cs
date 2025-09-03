using System.ComponentModel.DataAnnotations;

namespace EffortlyFit.Domain.Entities.Workouts;

public class WorkoutSchedule
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid WorkoutPlanId { get; set; }
    
    public DateTime ScheduledDate { get; set; }
    
    [StringLength(20)]
    public string Status { get; set; } = "Planned"; // Planned, Completed, Skipped
    
    [StringLength(500)]
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public virtual WorkoutPlan WorkoutPlan { get; set; } = null!;
    public virtual WorkoutSession? Session { get; set; } // Linked when workout is completed
}
