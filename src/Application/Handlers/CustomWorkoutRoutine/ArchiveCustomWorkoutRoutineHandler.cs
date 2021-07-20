using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.CustomWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.CustomWorkoutRoutine
{
    public class ArchiveCustomWorkoutRoutineHandler : ICommandHandler<ArchiveCustomWorkoutRoutine>
    {
        private readonly ICustomWorkoutRoutineManagementService _customWorkoutRoutineManagementService;
        public ArchiveCustomWorkoutRoutineHandler(ICustomWorkoutRoutineManagementService customWorkoutRoutineManagementService)
            => _customWorkoutRoutineManagementService = customWorkoutRoutineManagementService;
        public async Task HandleAsync(ArchiveCustomWorkoutRoutine command)
            => await _customWorkoutRoutineManagementService.ArchiveAsync
            (
                command.Id,
                command.AccountId
            );
    }
}