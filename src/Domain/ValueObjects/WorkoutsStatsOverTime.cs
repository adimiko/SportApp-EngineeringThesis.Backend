using System;

namespace Domain.ValueObjects
{
    public class WorkoutsStatsOverTime : WorkoutsStats
    {
        public readonly DateTime DateFrom;
        public readonly DateTime DateTo;
        public WorkoutsStatsOverTime(double volume, int numberOfCompletedWorkouts, int duration, DateTime dateFrom, DateTime dateTo)
            : base(volume, numberOfCompletedWorkouts, duration) 
        { 
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}