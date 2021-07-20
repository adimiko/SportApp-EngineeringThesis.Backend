namespace Domain.ValueObjects
{
    public class GlobalWorkoutsStats : WorkoutsStats
    {
        public GlobalWorkoutsStats(double volume, int numberOfCompletedWorkouts, int duration)
            : base(volume, numberOfCompletedWorkouts, duration) { }
    }
}