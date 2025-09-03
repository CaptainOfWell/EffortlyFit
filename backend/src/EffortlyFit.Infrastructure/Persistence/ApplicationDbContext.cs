using EffortlyFit.Domain.Entities;
using EffortlyFit.Domain.Entities.Statistics;
using EffortlyFit.Domain.Entities.Workouts;
using Microsoft.EntityFrameworkCore;

namespace EffortlyFit.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    // Constant
    private const string DefaultDatetimeSql = "datetime('now')";

    // User related
    public DbSet<User> Users { get; set; }
    
    // Exercise related
    public DbSet<Exercise> Exercises { get; set; }
    
    // Workout related
    public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<WorkoutSchedule> WorkoutSchedules { get; set; }
    public DbSet<WorkoutSession> WorkoutSessions { get; set; }
    public DbSet<WorkoutSessionExercise> WorkoutSessionExercises { get; set; }
    public DbSet<WorkoutSet> WorkoutSets { get; set; }
    
    // Statistics related
    public DbSet<BodyWeight> BodyWeights { get; set; }
    public DbSet<PersonalRecord> PersonalRecords { get; set; }
    public DbSet<WorkoutStatistics> WorkoutStatistics { get; set; }
    public DbSet<ProgressPhoto> ProgressPhotos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User configurations
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.Username).IsUnique();
            
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // Exercise configurations
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Name);
            entity.HasIndex(e => e.Category);
            entity.HasIndex(e => e.Level);
            entity.HasIndex(e => e.Equipment);
            
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // WorkoutPlan configurations
        modelBuilder.Entity<WorkoutPlan>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.Name);
            
            entity.HasOne(e => e.User)
                .WithMany(u => u.WorkoutPlans)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // WorkoutExercise configurations
        modelBuilder.Entity<WorkoutExercise>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.WorkoutPlanId);
            entity.HasIndex(e => e.ExerciseId);
            
            entity.HasOne(e => e.WorkoutPlan)
                .WithMany(wp => wp.Exercises)
                .HasForeignKey(e => e.WorkoutPlanId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Exercise)
                .WithMany(ex => ex.WorkoutExercises)
                .HasForeignKey(e => e.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // WorkoutSchedule configurations
        modelBuilder.Entity<WorkoutSchedule>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.WorkoutPlanId);
            entity.HasIndex(e => e.ScheduledDate);
            
            entity.HasOne(e => e.WorkoutPlan)
                .WithMany(wp => wp.Schedules)
                .HasForeignKey(e => e.WorkoutPlanId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Session)
                .WithOne(s => s.WorkoutSchedule)
                .HasForeignKey<WorkoutSession>(s => s.WorkoutScheduleId)
                .OnDelete(DeleteBehavior.SetNull);
                
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // WorkoutSession configurations
        modelBuilder.Entity<WorkoutSession>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.WorkoutPlanId);
            entity.HasIndex(e => e.StartTime);
            
            entity.HasOne(e => e.User)
                .WithMany(u => u.WorkoutSessions)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.WorkoutPlan)
                .WithMany(wp => wp.Sessions)
                .HasForeignKey(e => e.WorkoutPlanId)
                .OnDelete(DeleteBehavior.SetNull);
                
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // WorkoutSessionExercise configurations
        modelBuilder.Entity<WorkoutSessionExercise>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.WorkoutSessionId);
            entity.HasIndex(e => e.ExerciseId);
            
            entity.HasOne(e => e.WorkoutSession)
                .WithMany(ws => ws.Exercises)
                .HasForeignKey(e => e.WorkoutSessionId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Exercise)
                .WithMany(ex => ex.WorkoutSessionExercises)
                .HasForeignKey(e => e.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // WorkoutSet configurations
        modelBuilder.Entity<WorkoutSet>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.WorkoutSessionExerciseId);
            
            entity.HasOne(e => e.WorkoutSessionExercise)
                .WithMany(wse => wse.Sets)
                .HasForeignKey(e => e.WorkoutSessionExerciseId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // BodyWeight configurations
        modelBuilder.Entity<BodyWeight>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.MeasuredAt);
            
            entity.HasOne(e => e.User)
                .WithMany(u => u.BodyWeights)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // PersonalRecord configurations
        modelBuilder.Entity<PersonalRecord>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.ExerciseId);
            entity.HasIndex(e => new { e.UserId, e.ExerciseId, e.RecordType }).IsUnique();
            
            entity.HasOne(e => e.User)
                .WithMany(u => u.PersonalRecords)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Exercise)
                .WithMany()
                .HasForeignKey(e => e.ExerciseId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.WorkoutSession)
                .WithMany()
                .HasForeignKey(e => e.WorkoutSessionId)
                .OnDelete(DeleteBehavior.SetNull);
                
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // WorkoutStatistics configurations
        modelBuilder.Entity<WorkoutStatistics>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => new { e.UserId, e.PeriodType, e.PeriodStart }).IsUnique();
            
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.Property(e => e.CalculatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });

        // ProgressPhoto configurations
        modelBuilder.Entity<ProgressPhoto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.TakenAt);
            
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.Property(e => e.CreatedAt).HasDefaultValueSql(DefaultDatetimeSql);
        });
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.State is EntityState.Added or EntityState.Modified);

        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Modified && entity.Entity.GetType().GetProperty("UpdatedAt") != null)
            {
                entity.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}