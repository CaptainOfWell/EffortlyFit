using Effortly.Domain.Common;

namespace Effortly.Domain.Entities;

public class Workout : AuditableEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? ScheduledFor { get; set; }
    public int EstimatedDuration { get; set; } // minutes
    public bool IsTemplate { get; set; }
    public string? Tags { get; set; } // comma-separated

    // Navigation properties
    public User User { get; set; } = null!;
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    public ICollection<WorkoutSession> Sessions { get; set; } = new List<WorkoutSession>();
}