using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.CompletedWorkout;
using Application.Services.Interfaces;

namespace Application.Handlers.CompletedWorkout
{
    public class DeleteCompletedWorkoutHandler : ICommandHandler<DeleteCompletedWorkout>
    {
        private readonly ICompletedWorkoutManagementService _completedWorkoutManagementService;

        public DeleteCompletedWorkoutHandler(ICompletedWorkoutManagementService completedWorkoutManagementService)
            => _completedWorkoutManagementService = completedWorkoutManagementService;
        public async Task HandleAsync(DeleteCompletedWorkout command)
            => await _completedWorkoutManagementService.DeleteAsync
            (
                command.Id,
                command.AccountId
            );
    }
}