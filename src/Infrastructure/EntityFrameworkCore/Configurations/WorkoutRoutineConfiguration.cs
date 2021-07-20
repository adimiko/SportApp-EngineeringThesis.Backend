using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFrameworkCore.Configurations
{
    
    public class SampleWorkoutRoutineConfiguration : IEntityTypeConfiguration<SampleWorkoutRoutine>
    {
        public void Configure(EntityTypeBuilder<SampleWorkoutRoutine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("SampleWorkoutRoutine");
            builder.OwnsMany(wr => wr.Exercises, e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.WorkoutRoutineId).HasColumnName("SampleWorkoutRoutineId");
                e.WithOwner().HasForeignKey(x => x.WorkoutRoutineId);
                e.ToTable("SampleExerciseRoutine");
            });
        }
    }
    
}