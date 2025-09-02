using EffortlyFit.Domain.Common;

namespace EffortlyFit.Domain.Entities;

public class WorkoutExercise : BaseEntity
{
    public Guid WorkoutId { get; set; }
    public Guid ExerciseId { get; set; }
    public int OrderIndex { get; set; }
    public int Sets { get; set; }
    public int TargetReps { get; set; }
    public double? TargetWeight { get; set; }
    public TimeSpan? RestDuration { get; set; }
    public string? Notes { get; set; }
    
    // Navigation properties
    public Workout Workout { get; set; } = null!;
    public Exercise Exercise { get; set; } = null!;
    public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
}