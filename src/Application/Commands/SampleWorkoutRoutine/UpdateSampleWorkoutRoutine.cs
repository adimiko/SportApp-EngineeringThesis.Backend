using System;
using System.Collections.Generic;
using Application.Commands.WorkoutRoutine;

namespace Application.Commands.SampleWorkoutRoutine
{
    public class UpdateSampleWorkoutRoutine : ICommand
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public IEnumerable<UpdateExercise> Exercises {get; set;}
    }
}