using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFrameworkCore.Configurations
{
    public class CompletedWorkoutConfiguration : IEntityTypeConfiguration<CompletedWorkout>
    {
        public void Configure(EntityTypeBuilder<CompletedWorkout> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("CompletedWorkout");
            builder.OwnsMany(wr => wr.Exercises, e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.CompletedWorkoutId).HasColumnName("CompletedWorkoutId");
                e.WithOwner().HasForeignKey(x => x.CompletedWorkoutId);
                e.ToTable("CompletedExercise");
                e.OwnsMany(e => e.Sets, s =>
                {
                    s.HasKey(e => e.Id);
                    s.WithOwner().HasForeignKey(x => x.CompletedExerciseId);
                    s.Property(s => s.CompletedExerciseId).HasColumnName("CompletedExerciseId");
                    s.ToTable("CompletedSet");
                });
            });
        }
    }
}