using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.SampleWorkoutRoutine;
using Application.Commands.WorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.SampleWorkoutRoutine
{
    public class CreateSampleWorkoutRoutineHandler : ICommandHandler<CreateSampleWorkoutRoutine>
    {
        private readonly ISampleWorkoutRoutineManagementService _sampleWorkoutRoutineManagementService;
        public CreateSampleWorkoutRoutineHandler(ISampleWorkoutRoutineManagementService sampleWorkoutRoutineManagementService)
            => _sampleWorkoutRoutineManagementService = sampleWorkoutRoutineManagementService;

        public async Task HandleAsync(CreateSampleWorkoutRoutine command)
            => await _sampleWorkoutRoutineManagementService.CreateAsync
            (
                command.Id,
                command.Name,
                command.Exercises
            );
    }
}