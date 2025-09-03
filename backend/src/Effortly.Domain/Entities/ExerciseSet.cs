using Effortly.Domain.Common;
using Effortly.Domain.Enums;

namespace Effortly.Domain.Entities;

public class ExerciseSet : BaseEntity
{
    public Guid SessionId { get; set; }
    public Guid ExerciseId { get; set; }
    public int SetNumber { get; set; }
    public int? Reps { get; set; }
    public decimal? Weight { get; set; }
    public int? Duration { get; set; } // seconds
    public decimal? Distance { get; set; } // for cardio
    public SetType Type { get; set; }
    public DateTime CompletedAt { get; set; }
    public int? RestAfter { get; set; } // seconds
    public string? Notes { get; set; }
    
    // Navigation properties
    public WorkoutSession Session { get; set; } = null!;
    public Exercise Exercise { get; set; } = null!;
}