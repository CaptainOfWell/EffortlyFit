using System.ComponentModel.DataAnnotations;

namespace EffortlyFit.Domain.Entities.Workouts;

public class WorkoutSet
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required] public Guid WorkoutSessionExerciseId { get; set; }

    public int SetNumber { get; set; }

    public int? Reps { get; set; }
    public double? Weight { get; set; } // in kg
    public int? DurationSeconds { get; set; } // for time-based exercises
    public double? Distance { get; set; } // for cardio exercises (in km)

    [StringLength(20)] public string? SetType { get; set; } // Normal, Warmup, Drop, Failure

    [StringLength(500)] public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual WorkoutSessionExercise WorkoutSessionExercise { get; set; } = null!;
}
