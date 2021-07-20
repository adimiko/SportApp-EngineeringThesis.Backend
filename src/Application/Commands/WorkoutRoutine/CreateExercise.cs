using System;

namespace Application.Commands.WorkoutRoutine
{
    public class CreateExercise : ICommand
    {
        public Guid ExerciseInfoId {get; set;}
        public int Order {get; set;}
        public int NumberOfSets {get; set;}
    }
}