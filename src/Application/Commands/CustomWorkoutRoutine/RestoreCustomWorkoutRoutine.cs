using System;

namespace Application.Commands.CustomWorkoutRoutine
{
    public class RestoreCustomWorkoutRoutine : ICommand
    {
        public Guid Id {get; set;}
        public Guid AccountId {get; set;}
    }
}