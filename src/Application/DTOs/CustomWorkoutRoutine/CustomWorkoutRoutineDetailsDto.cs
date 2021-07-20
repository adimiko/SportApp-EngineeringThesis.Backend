using System;
using System.Collections.Generic;
using Application.DTOs.WorkoutRoutine;

namespace Application.DTOs.CustomWorkoutRoutine
{
    public class CustomWorkoutRoutineDetailsDto
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public IEnumerable<ExerciseDetailsDto> Exercises {get; set;}
    }
}