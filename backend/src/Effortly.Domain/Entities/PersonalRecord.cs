using Effortly.Domain.Common;

namespace Effortly.Domain.Entities;

public class PersonalRecord : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ExerciseId { get; set; }
    public string RecordType { get; set; } = string.Empty; // "1RM", "3RM", "5RM", "Max Reps", etc.
    public decimal Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public DateTime AchievedOn { get; set; }
    public Guid? SessionId { get; set; }
    
    // Navigation properties
    public User User { get; set; } = null!;
    public Exercise Exercise { get; set; } = null!;
    public WorkoutSession? Session { get; set; }
}