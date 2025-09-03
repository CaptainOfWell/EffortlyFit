using System.ComponentModel.DataAnnotations;
using EffortlyFit.Domain.Entities.Workouts;

namespace EffortlyFit.Domain.Entities;

public class Exercise
{
    [Key]
    [StringLength(200)]
    public string Id { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    public string Name { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Force { get; set; } // static, pull, push

    [Required]
    [StringLength(20)]
    public string Level { get; set; } = string.Empty; // beginner, intermediate, expert

    [StringLength(20)]
    public string? Mechanic { get; set; } // isolation, compound

    [StringLength(50)]
    public string? Equipment { get; set; } // dumbbell, barbell, body only, etc.

    [Required]
    [StringLength(50)]
    public string Category { get; set; } = string.Empty; // strength, cardio, stretching, etc.

    // Store as JSON strings for flexibility
    public string PrimaryMuscles { get; set; } = "[]"; // JSON array of muscle groups
    public string SecondaryMuscles { get; set; } = "[]"; // JSON array of muscle groups
    public string Instructions { get; set; } = "[]"; // JSON array of instruction steps
    public string Images { get; set; } = "[]"; // JSON array of image paths

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    public virtual ICollection<WorkoutSessionExercise> WorkoutSessionExercises { get; set; } = new List<WorkoutSessionExercise>();
}
