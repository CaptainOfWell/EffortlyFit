using System.ComponentModel.DataAnnotations;

namespace EffortlyFit.Domain.Entities.Workouts;

public class WorkoutExercise
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid WorkoutPlanId { get; set; }

    [Required]
    public string ExerciseId { get; set; } = string.Empty;

    public int Order { get; set; } // Exercise order in the workout

    public int? PlannedSets { get; set; }
    public int? PlannedReps { get; set; }
    public double? PlannedWeight { get; set; } // in kg
    public int? PlannedDurationSeconds { get; set; } // for time-based exercises
    public int? RestTimeSeconds { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual WorkoutPlan WorkoutPlan { get; set; } = null!;
    public virtual Exercise Exercise { get; set; } = null!;
}
