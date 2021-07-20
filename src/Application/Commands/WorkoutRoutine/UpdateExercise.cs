using System;

namespace Application.Commands.WorkoutRoutine
{
    public class UpdateExercise : ICommand
    {
        public Guid Id {get; set;}
        public Guid ExerciseInfoId {get; set;}
        public int Order {get; set;}
        public int NumberOfSets {get; set;}
    }
}