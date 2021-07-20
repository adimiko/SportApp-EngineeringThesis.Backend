using System;
using System.Collections.Generic;
using Application.Commands.WorkoutRoutine;

namespace Application.Commands.SampleWorkoutRoutine
{
    public class CreateSampleWorkoutRoutine : ICommand
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public string Name {get; set;}
        public IEnumerable<CreateExercise> Exercises {get; set;}
    }
}