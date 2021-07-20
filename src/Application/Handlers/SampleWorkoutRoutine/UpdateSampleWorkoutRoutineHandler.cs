using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.SampleWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.SampleWorkoutRoutine
{
    public class UpdateSampleWorkoutRoutineHandler : ICommandHandler<UpdateSampleWorkoutRoutine>
    {
        private readonly ISampleWorkoutRoutineManagementService _sampleWorkoutRoutineManagementService;
        public UpdateSampleWorkoutRoutineHandler(ISampleWorkoutRoutineManagementService sampleWorkoutRoutineManagementService)
            => _sampleWorkoutRoutineManagementService = sampleWorkoutRoutineManagementService;
        public async Task HandleAsync(UpdateSampleWorkoutRoutine command)
            => await _sampleWorkoutRoutineManagementService.UpdateAsync(command.Id, command.Name, command.Exercises);
    }
}