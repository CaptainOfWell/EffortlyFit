using System.ComponentModel.DataAnnotations;

namespace EffortlyFit.Domain.Entities.Workouts;

public class WorkoutPlan
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserId { get; set; }

    [Required] [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(50)]
    public string? Difficulty { get; set; } // Beginner, Intermediate, Advanced

    public int? EstimatedDurationMinutes { get; set; }

    [StringLength(100)]
    public string? Category { get; set; } // Push, Pull, Legs, Cardio, etc.

    public bool IsTemplate { get; set; } // For reusable workout templates

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual User User { get; set; } = null!;
    public virtual ICollection<WorkoutExercise> Exercises { get; set; } = new List<WorkoutExercise>();
    public virtual ICollection<WorkoutSession> Sessions { get; set; } = new List<WorkoutSession>();
    public virtual ICollection<WorkoutSchedule> Schedules { get; set; } = new List<WorkoutSchedule>();
}
