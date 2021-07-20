using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.CustomWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.CustomWorkoutRoutine
{
    public class CreateCustomWorkoutRoutineHandler : ICommandHandler<CreateCustomWorkoutRoutine>
    {
        private readonly ICustomWorkoutRoutineManagementService _customWorkoutRoutineManagementService;
        public CreateCustomWorkoutRoutineHandler(ICustomWorkoutRoutineManagementService customWorkoutRoutineManagementService)
            => _customWorkoutRoutineManagementService = customWorkoutRoutineManagementService;
        public async Task HandleAsync(CreateCustomWorkoutRoutine command)
            => await _customWorkoutRoutineManagementService.CreateAsync
            (
                command.Id,
                command.AccountId,
                command.Name,
                command.Exercises
            );
    }
}