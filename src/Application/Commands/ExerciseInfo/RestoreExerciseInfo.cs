using System;

namespace Application.Commands.ExerciseInfo
{
    public class RestoreExerciseInfo : ICommand
    {
        public Guid Id {get; set;}
    }
}