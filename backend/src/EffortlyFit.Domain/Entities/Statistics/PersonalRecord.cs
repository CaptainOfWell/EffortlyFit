using System.ComponentModel.DataAnnotations;
using EffortlyFit.Domain.Entities.Workouts;

namespace EffortlyFit.Domain.Entities.Statistics;

public class PersonalRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    public string ExerciseId { get; set; } = string.Empty;
    
    [StringLength(20)]
    public string RecordType { get; set; } = "1RM"; // 1RM, MaxReps, MaxWeight, MaxVolume, MaxDuration
    
    public double Value { get; set; } // The record value (weight, reps, duration, etc.)
    
    [StringLength(20)]
    public string Unit { get; set; } = "kg"; // kg, lbs, reps, seconds, minutes
    
    public DateTime AchievedAt { get; set; }
    
    public Guid? WorkoutSessionId { get; set; } // Link to the session where it was achieved
    
    [StringLength(500)]
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public virtual User User { get; set; } = null!;
    public virtual Exercise Exercise { get; set; } = null!;
    public virtual WorkoutSession? WorkoutSession { get; set; }
}
