using Effortly.Domain.Common;
using Effortly.Domain.Enums;

namespace Effortly.Domain.Entities;

public class WorkoutSession : AuditableEntity
{
    public Guid UserId { get; set; }
    public Guid? WorkoutId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public SessionStatus Status { get; set; }
    public int? TotalVolume { get; set; } // calculated field
    public int? Duration { get; set; } // seconds
    public string? Notes { get; set; }
    public bool NeedsSync { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
    public Workout? Workout { get; set; }
    public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
}