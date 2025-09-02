using EffortlyFit.Domain.Common;

namespace EffortlyFit.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public double? CurrentWeight { get; set; }
    public double? Height { get; set; }
    public string? ProfilePictureUrl { get; set; }

    // Navigation properties
    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    public ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    public ICollection<BodyWeightRecord> BodyWeightRecords { get; set; } = new List<BodyWeightRecord>();
}