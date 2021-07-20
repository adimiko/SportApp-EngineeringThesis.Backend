using System;
using System.Collections.Generic;

namespace Application.DTOs.CompletedWorkout
{
    public class CompletedWorkoutDetailsDto
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string WorkoutNote {get; set;}
        public int Duration {get; set;}
        public DateTime Date {get; set;}
        public IEnumerable<CompletedExerciseDetailsDto> Exercises {get; set;}
    }
}