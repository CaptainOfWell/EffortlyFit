using EffortlyFit.Domain.Common;
using EffortlyFit.Domain.Enums;

namespace EffortlyFit.Domain.Entities;

public class Workout : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid UserId { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public TimeSpan? EstimatedDuration { get; set; }
    public WorkoutStatus Status { get; set; }
    public bool IsTemplate { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    public ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
}