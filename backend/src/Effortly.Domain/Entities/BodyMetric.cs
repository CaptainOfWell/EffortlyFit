using Effortly.Domain.Common;

namespace Effortly.Domain.Entities;

public class BodyMetric : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime MeasuredAt { get; set; }
    public decimal? Weight { get; set; }
    public decimal? BodyFat { get; set; }
    public decimal? MuscleMass { get; set; }
    public Dictionary<string, decimal> Measurements { get; set; } = new(); // chest, arms, waist, etc.
    public string? Notes { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
}