using System;

namespace Application.DTOs.WorkoutStatistics
{
    public class WorkoutsStatsOverTimeDto
    {
        public double Volume {get; set;}
        public int NumberOfCompletedWorkouts {get; set;}
        public int Duration {get; set;}
        public DateTime DateFrom {get; set;}
        public DateTime DateTo {get; set;}

    }
}