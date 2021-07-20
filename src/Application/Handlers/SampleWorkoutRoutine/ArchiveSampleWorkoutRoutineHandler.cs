using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.SampleWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.SampleWorkoutRoutine
{
    public class ArchiveSampleWorkoutRoutineHandler : ICommandHandler<ArchiveSampleWorkoutRoutine>
    {
        private readonly ISampleWorkoutRoutineManagementService _sampleWorkoutRoutineManagementService;
        public ArchiveSampleWorkoutRoutineHandler(ISampleWorkoutRoutineManagementService sampleWorkoutRoutineManagementService)
            => _sampleWorkoutRoutineManagementService = sampleWorkoutRoutineManagementService;
        public async Task HandleAsync(ArchiveSampleWorkoutRoutine command)
            => await _sampleWorkoutRoutineManagementService.ArchiveAsync(command.Id);
    }
}