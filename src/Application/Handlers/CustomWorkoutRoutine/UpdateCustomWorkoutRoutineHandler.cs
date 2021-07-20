using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.CustomWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.CustomWorkoutRoutine
{
    public class UpdateCustomWorkoutRoutineHandler : ICommandHandler<UpdateCustomWorkoutRoutine>
    {
        private readonly ICustomWorkoutRoutineManagementService _customWorkoutRoutineManagementService;
        public UpdateCustomWorkoutRoutineHandler(ICustomWorkoutRoutineManagementService customWorkoutRoutineManagementService)
            => _customWorkoutRoutineManagementService = customWorkoutRoutineManagementService;
        public async Task HandleAsync(UpdateCustomWorkoutRoutine command)
            => await _customWorkoutRoutineManagementService.UpdateAsync(command.Id, command.Name, command.Exercises);
    }
}