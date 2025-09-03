using System.ComponentModel.DataAnnotations;
using EffortlyFit.Domain.Entities.Statistics;
using EffortlyFit.Domain.Entities.Workouts;

namespace EffortlyFit.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(100)] public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string Email { get; set; } = string.Empty;

    [StringLength(200)]
    public string? FirstName { get; set; }

    [StringLength(200)]
    public string? LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    [StringLength(10)]
    public string? Gender { get; set; } // Male, Female, Other

    public double? Height { get; set; } // in cm

    public double? Weight { get; set; } // in kg

    [StringLength(20)]
    public string? ActivityLevel { get; set; } // Sedentary, Light, Moderate, Active, VeryActive

    [StringLength(500)]
    public string? Goals { get; set; } // User's fitness goals

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastSyncAt { get; set; }

    // Navigation properties
    public virtual ICollection<WorkoutPlan> WorkoutPlans { get; set; } = new List<WorkoutPlan>();
    public virtual ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    public virtual ICollection<BodyWeight> BodyWeights { get; set; } = new List<BodyWeight>();
    public virtual ICollection<PersonalRecord> PersonalRecords { get; set; } = new List<PersonalRecord>();
}
