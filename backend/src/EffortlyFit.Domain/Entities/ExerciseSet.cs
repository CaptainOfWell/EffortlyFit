using EffortlyFit.Domain.Common;

namespace EffortlyFit.Domain.Entities;

public class ExerciseSet : BaseEntity
{
    public Guid WorkoutSessionId { get; set; }
    public Guid WorkoutExerciseId { get; set; }
    public int SetNumber { get; set; }
    public int Reps { get; set; }
    public double? Weight { get; set; }
    public TimeSpan? Duration { get; set; } // For time-based exercises
    public double? Distance { get; set; } // For distance-based exercises
    public string? Notes { get; set; }
    
    // Navigation properties
    public WorkoutSession WorkoutSession { get; set; } = null!;
    public WorkoutExercise WorkoutExercise { get; set; } = null!;
}