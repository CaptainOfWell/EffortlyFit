using System.ComponentModel.DataAnnotations;

namespace EffortlyFit.Domain.Entities.Workouts;

public class WorkoutSessionExercise
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid WorkoutSessionId { get; set; }
    
    [Required]
    public string ExerciseId { get; set; } = string.Empty;
    
    public int Order { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    
    [StringLength(500)]
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public virtual WorkoutSession WorkoutSession { get; set; } = null!;
    public virtual Exercise Exercise { get; set; } = null!;
    public virtual ICollection<WorkoutSet> Sets { get; set; } = new List<WorkoutSet>();
}
