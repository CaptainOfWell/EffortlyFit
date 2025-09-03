using Effortly.Domain.Common;
using Effortly.Domain.Enums;

namespace Effortly.Domain.Entities;

public class Exercise : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public Category Category { get; set; }
    public List<string> PrimaryMuscles { get; set; } = new();
    public List<string> SecondaryMuscles { get; set; } = new();
    public Equipment? Equipment { get; set; }
    public Difficulty Difficulty { get; set; }
    public List<string> Instructions { get; set; } = new();
    public List<string> Images { get; set; } = new();

    // Navigation properties
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
}