using System;
using System.Collections.Generic;
using Application.Commands.WorkoutRoutine;

namespace Application.Commands.CustomWorkoutRoutine
{
    public class CreateCustomWorkoutRoutine : ICommand
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public Guid AccountId {get; set;}
        public string Name {get; set;}
        public IEnumerable<CreateExercise> Exercises {get; set;}
    }
}