using System.Text.Json;
using Effortly.Domain.Common;
using Effortly.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Effortly.Infrastructure.Data;

public class EffortlyDbContext(DbContextOptions<EffortlyDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<Workout> Workouts => Set<Workout>();
    public DbSet<WorkoutExercise> WorkoutExercises => Set<WorkoutExercise>();
    public DbSet<WorkoutSession> WorkoutSessions => Set<WorkoutSession>();
    public DbSet<ExerciseSet> WorkoutSets => Set<ExerciseSet>();
    public DbSet<PersonalRecord> PersonalRecords => Set<PersonalRecord>();
    public DbSet<BodyMetric> BodyMetrics => Set<BodyMetric>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Set default schema
        modelBuilder.HasDefaultSchema("effortly");

        // User configuration
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            // Configure UserSettings as owned entity (stored as JSON)
            entity.OwnsOne(e => e.Settings, settings => { settings.ToJson(); });
        });

        // Exercise configuration
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.ToTable("Exercises");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.Slug)
                .HasMaxLength(200)
                .IsRequired();

            entity.HasIndex(e => e.Slug)
                .IsUnique();

            // Store arrays as JSON
            entity.Property(e => e.PrimaryMuscles)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!)!);

            entity.Property(e => e.SecondaryMuscles)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!)!);

            entity.Property(e => e.Instructions)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!)!);

            entity.Property(e => e.Images)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!)!);

            // Enum conversions
            entity.Property(e => e.Category)
                .HasConversion<string>();

            entity.Property(e => e.Equipment)
                .HasConversion<string>();

            entity.Property(e => e.Difficulty)
                .HasConversion<string>();
        });

        // Workout configuration
        modelBuilder.Entity<Workout>(entity =>
        {
            entity.ToTable("Workouts");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.Description)
                .HasMaxLength(1000);

            entity.HasOne(e => e.User)
                .WithMany(u => u.Workouts)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.ScheduledFor);
        });

        // WorkoutExercise configuration
        modelBuilder.Entity<WorkoutExercise>(entity =>
        {
            entity.ToTable("WorkoutExercises");

            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Workout)
                .WithMany(w => w.WorkoutExercises)
                .HasForeignKey(e => e.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Exercise)
                .WithMany(ex => ex.WorkoutExercises)
                .HasForeignKey(e => e.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.PlannedWeight)
                .HasPrecision(8, 2);

            entity.HasIndex(e => new { e.WorkoutId, e.Order });
        });

        // WorkoutSession configuration
        modelBuilder.Entity<WorkoutSession>(entity =>
        {
            entity.ToTable("WorkoutSessions");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.Status)
                .HasConversion<string>();

            entity.HasOne(e => e.User)
                .WithMany(u => u.WorkoutSessions)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Workout)
                .WithMany(w => w.Sessions)
                .HasForeignKey(e => e.WorkoutId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.StartTime);
            entity.HasIndex(e => e.Status);
        });

        // ExerciseSet configuration
        modelBuilder.Entity<ExerciseSet>(entity =>
        {
            entity.ToTable("ExerciseSets");

            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Session)
                .WithMany(s => s.ExerciseSets)
                .HasForeignKey(e => e.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Exercise)
                .WithMany(ex => ex.ExerciseSets)
                .HasForeignKey(e => e.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.Weight)
                .HasPrecision(8, 2);

            entity.Property(e => e.Distance)
                .HasPrecision(8, 2);

            entity.Property(e => e.Type)
                .HasConversion<string>();

            entity.HasIndex(e => new { e.SessionId, e.SetNumber });
        });

        // PersonalRecord configuration
        modelBuilder.Entity<PersonalRecord>(entity =>
        {
            entity.ToTable("PersonalRecords");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.RecordType)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.Value)
                .HasPrecision(10, 2);

            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .IsRequired();

            entity.HasOne(e => e.User)
                .WithMany(u => u.PersonalRecords)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Exercise)
                .WithMany()
                .HasForeignKey(e => e.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Session)
                .WithMany()
                .HasForeignKey(e => e.SessionId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(e => new { e.UserId, e.ExerciseId, e.RecordType });
        });

        // BodyMetric configuration
        modelBuilder.Entity<BodyMetric>(entity =>
        {
            entity.ToTable("BodyMetrics");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Weight)
                .HasPrecision(6, 2);

            entity.Property(e => e.BodyFat)
                .HasPrecision(5, 2);

            entity.Property(e => e.MuscleMass)
                .HasPrecision(6, 2);

            // Store measurements as JSON
            entity.Property(e => e.Measurements)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                    v => JsonSerializer.Deserialize<Dictionary<string, decimal>>(v, (JsonSerializerOptions)null!)!);

            entity.HasOne(e => e.User)
                .WithMany(u => u.BodyMetrics)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => new { e.UserId, e.MeasuredAt });
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries().Where(e =>
            e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified)
        );

        foreach (var entityEntry in entries)
        {
            if (entityEntry.Entity is BaseEntity entity)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                else
                {
                    entity.UpdatedAt = DateTime.UtcNow;
                }
            }

            if (entityEntry.Entity is AuditableEntity auditableEntity)
            {
                // TODO: Get current user from service
                if (entityEntry.State == EntityState.Added)
                {
                    auditableEntity.CreatedBy = "system"; // Will be replaced with actual user
                }
                else
                {
                    auditableEntity.UpdatedBy = "system"; // Will be replaced with actual user
                }
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}