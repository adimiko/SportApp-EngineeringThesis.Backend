using System;

namespace Application.Commands.CompletedWorkout
{
    public class DeleteCompletedWorkout : ICommand
    {
        public Guid Id {get; set;}
        public Guid AccountId {get; set;}
    }
}