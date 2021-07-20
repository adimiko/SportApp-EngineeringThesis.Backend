namespace Domain.ValueObjects
{
    public abstract class WorkoutsStats
    {
        public readonly double? Volume;
        public readonly int NumberOfCompletedWorkouts;
        public readonly int? Duration;


        public WorkoutsStats(double volume, int numberOfCompletedWorkouts, int duration)
        {
            Volume = volume;
            NumberOfCompletedWorkouts = numberOfCompletedWorkouts;
            Duration = duration;
        }
    }
}