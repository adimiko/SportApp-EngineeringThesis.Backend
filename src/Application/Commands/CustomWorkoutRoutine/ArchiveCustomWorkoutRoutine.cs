using System;

namespace Application.Commands.CustomWorkoutRoutine
{
    public class ArchiveCustomWorkoutRoutine : ICommand
    {
        public Guid Id {get; set;}
        public Guid AccountId {get; set;}
    }
}