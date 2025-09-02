using EffortlyFit.Domain.Common;
using EffortlyFit.Domain.Enums;

namespace EffortlyFit.Domain.Entities;

public class Exercise : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ForceType? Force { get; set; }          // static, push, pull
    public DifficultyLevel Level { get; set; }     // beginner, intermediate, expert
    public MechanicType? Mechanic { get; set; }    // isolation, compound
    public EquipmentType? Equipment { get; set; }

    public List<MuscleGroup> PrimaryMuscleGroups { get; set; } = new();
    public List<MuscleGroup> SecondaryMuscleGroups { get; set; } = new();

    public ExerciseCategory Category { get; set; }

    public List<string> Instructions { get; set; } = new();
    public List<string> Images { get; set; } = new();

    public string? VideoUrl { get; set; }
    public bool IsCustom { get; set; }
    public Guid? CreatedByUserId { get; set; }

    // Navigation properties
    public User? CreatedByUser { get; set; }
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}
