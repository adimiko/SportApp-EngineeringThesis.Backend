using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.CustomWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.CustomWorkoutRoutine
{
    public class RestoreCustomWorkoutRoutineHandler : ICommandHandler<RestoreCustomWorkoutRoutine>
    {
        private readonly ICustomWorkoutRoutineManagementService _customWorkoutRoutineManagementService;
        public RestoreCustomWorkoutRoutineHandler(ICustomWorkoutRoutineManagementService customWorkoutRoutineManagementService)
            => _customWorkoutRoutineManagementService = customWorkoutRoutineManagementService;
        public async Task HandleAsync(RestoreCustomWorkoutRoutine command)
            => await _customWorkoutRoutineManagementService.RestoreAsync
            (
                command.Id,
                command.AccountId
            );
    }
}