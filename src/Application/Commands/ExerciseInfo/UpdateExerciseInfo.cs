using System;

namespace Application.Commands.ExerciseInfo
{
    public class UpdateExerciseInfo : ICommand
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
    }
}