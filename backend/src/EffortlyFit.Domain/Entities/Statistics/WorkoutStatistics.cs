using System.ComponentModel.DataAnnotations;

namespace EffortlyFit.Domain.Entities.Statistics;

public class WorkoutStatistics
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid UserId { get; set; }
    
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    
    [StringLength(20)]
    public string PeriodType { get; set; } = "Weekly"; // Daily, Weekly, Monthly, Yearly
    
    // Aggregate statistics
    public int TotalWorkouts { get; set; }
    public int TotalMinutes { get; set; }
    public double TotalCaloriesBurned { get; set; }
    public double TotalVolumeKg { get; set; } // Total weight lifted
    
    // Most active muscle groups (JSON)
    public string MuscleGroupBreakdown { get; set; } = "{}"; // JSON object with muscle group counts
    
    // Exercise frequency (JSON)
    public string ExerciseFrequency { get; set; } = "{}"; // JSON object with exercise counts
    
    public DateTime CalculatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public virtual User User { get; set; } = null!;
}
