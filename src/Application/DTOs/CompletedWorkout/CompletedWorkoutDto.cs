using System;

namespace Application.DTOs.CompletedWorkout
{
    public class CompletedWorkoutDto
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string WorkoutNote {get; set;}
        public DateTime Date {get; set;}
    }
}