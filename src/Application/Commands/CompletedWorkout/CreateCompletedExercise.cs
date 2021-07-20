using System;
using System.Collections.Generic;

namespace Application.Commands.CompletedWorkout
{
    public class CreateCompletedExercise : ICommand
    {
        public Guid ExerciseInfoId {get; set;}
        public int Order {get; set;}
        public IEnumerable<CreateCompletedSet> Sets {get; set;}
    }
}