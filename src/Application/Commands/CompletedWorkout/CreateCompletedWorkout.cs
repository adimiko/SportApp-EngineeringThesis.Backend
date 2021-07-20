using System;
using System.Collections.Generic;

namespace Application.Commands.CompletedWorkout
{
    public class CreateCompletedWorkout : ICommand
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public Guid AccountId {get; set;}
        public string Name {get; set;}
        public string WorkoutNote {get; set;}
        public int Duration {get; set;}
        public DateTime Date {get; set;} = DateTime.UtcNow;
        public IEnumerable<CreateCompletedExercise> Exercises {get; set;}
    }
}