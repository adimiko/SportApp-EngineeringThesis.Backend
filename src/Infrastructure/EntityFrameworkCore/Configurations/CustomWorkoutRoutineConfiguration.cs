using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFrameworkCore.Configurations
{
    public class CustomWorkoutRoutineConfiguration : IEntityTypeConfiguration<CustomWorkoutRoutine>
    {
        public void Configure(EntityTypeBuilder<CustomWorkoutRoutine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("CustomWorkoutRoutine");
            builder.OwnsMany(wr => wr.Exercises, e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.WorkoutRoutineId).HasColumnName("CustomWorkoutRoutineId");
                e.WithOwner().HasForeignKey(x => x.WorkoutRoutineId);
                e.ToTable("CustomExerciseRoutine");
            });
        }
    }
}