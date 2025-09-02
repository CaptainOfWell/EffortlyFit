using EffortlyFit.Domain.Common;

namespace EffortlyFit.Domain.Entities;

public class WorkoutSession : BaseEntity
{
    public Guid WorkoutId { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public TimeSpan Duration => EndTime.HasValue ? EndTime.Value - StartTime : TimeSpan.Zero;
    public string? Notes { get; set; }
    public int? Rating { get; set; } // 1-5 stars
    
    // Navigation properties
    public Workout Workout { get; set; } = null!;
    public User User { get; set; } = null!;
    public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
}