using EffortlyFit.Domain.Common;

namespace EffortlyFit.Domain.Entities;

public class BodyWeightRecord : BaseEntity
{
    public Guid UserId { get; set; }
    public double Weight { get; set; }
    public DateTime RecordedDate { get; set; }
    public string? Notes { get; set; }
    
    // Navigation properties
    public User User { get; set; } = null!;
}