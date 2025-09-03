using System.ComponentModel.DataAnnotations;

namespace EffortlyFit.Domain.Entities.Workouts;

public class WorkoutSession
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid UserId { get; set; }
    
    public Guid? WorkoutPlanId { get; set; } // Can be null for freestyle workouts
    
    public Guid? WorkoutScheduleId { get; set; } // Links to scheduled workout
    
    [StringLength(200)]
    public string? Name { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    
    public int? DurationMinutes { get; set; } // Calculated field
    
    [StringLength(20)]
    public string Status { get; set; } = "InProgress"; // InProgress, Completed, Cancelled
    
    [StringLength(1000)]
    public string? Notes { get; set; }
    
    public double? CaloriesBurned { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public virtual User User { get; set; } = null!;
    public virtual WorkoutPlan? WorkoutPlan { get; set; }
    public virtual WorkoutSchedule? WorkoutSchedule { get; set; }
    public virtual ICollection<WorkoutSessionExercise> Exercises { get; set; } = new List<WorkoutSessionExercise>();
}
