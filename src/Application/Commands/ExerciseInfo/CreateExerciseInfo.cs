using System;

namespace Application.Commands.ExerciseInfo
{
    public class CreateExerciseInfo : ICommand
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public string Name {get; set;}
        public string Description {get; set;}
    }
}