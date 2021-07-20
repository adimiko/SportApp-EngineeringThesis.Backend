using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.ExerciseInfo;
using Application.Services.Interfaces;

namespace Application.Handlers.ExerciseInfo
{
    public class ArchiveExerciseInfoHandler : ICommandHandler<ArchiveExerciseInfo>
    {
        private readonly IExerciseInfoManagementService _exerciseInfoManagementService;
        public ArchiveExerciseInfoHandler(IExerciseInfoManagementService exerciseInfoManagementService)
            => _exerciseInfoManagementService = exerciseInfoManagementService;

        public async Task HandleAsync(ArchiveExerciseInfo command)
            => await _exerciseInfoManagementService.ArchiveAsync(command.Id);

    }
}