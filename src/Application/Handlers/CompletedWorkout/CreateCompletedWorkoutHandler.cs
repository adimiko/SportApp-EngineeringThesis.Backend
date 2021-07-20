using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.CompletedWorkout;
using Application.Services.Interfaces;

namespace Application.Handlers.CompletedWorkout
{
    public class CreateCompletedWorkoutHandler : ICommandHandler<CreateCompletedWorkout>
    {
        private readonly ICompletedWorkoutManagementService _completedWorkoutManagementService;

        public CreateCompletedWorkoutHandler(ICompletedWorkoutManagementService completedWorkoutManagementService)
            => _completedWorkoutManagementService = completedWorkoutManagementService;
        public async Task HandleAsync(CreateCompletedWorkout command)
            => await _completedWorkoutManagementService.CreateAsync
            (
                command.Id,
                command.AccountId,
                command.Name,
                command.WorkoutNote,
                command.Duration,
                command.Date,
                command.Exercises
            );
    }
}