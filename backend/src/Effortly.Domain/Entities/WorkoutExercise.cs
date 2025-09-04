using Effortly.Domain.Common;

namespace Effortly.Domain.Entities;

public class WorkoutExercise : BaseEntity
{
    public Guid WorkoutId { get; set; }
    public Guid ExerciseId { get; set; }
    public int Order { get; set; }
    public int PlannedSets { get; set; }
    public int PlannedReps { get; set; }
    public decimal? PlannedWeight { get; set; }
    public int? PlannedDuration { get; set; } // seconds
    public int? RestTime { get; set; } // seconds
    public string? Notes { get; set; }

    // Navigation properties
    public Workout Workout { get; set; } = null!;
    public Exercise Exercise { get; set; } = null!;
}