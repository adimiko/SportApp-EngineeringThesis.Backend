using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.SampleWorkoutRoutine;
using Application.Commands.WorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.SampleWorkoutRoutine
{
    public class RestoreSampleWorkoutRoutineHandler : ICommandHandler<RestoreSampleWorkoutRoutine>
    {
        private readonly ISampleWorkoutRoutineManagementService _sampleWorkoutRoutineManagementService;
        public RestoreSampleWorkoutRoutineHandler(ISampleWorkoutRoutineManagementService sampleWorkoutRoutineManagementService)
            => _sampleWorkoutRoutineManagementService = sampleWorkoutRoutineManagementService;
        public async Task HandleAsync(RestoreSampleWorkoutRoutine command)
            => await _sampleWorkoutRoutineManagementService.RestoreAsync(command.Id);
    }
}