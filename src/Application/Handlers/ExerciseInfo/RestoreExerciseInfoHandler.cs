using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.ExerciseInfo;
using Application.Services.Interfaces;

namespace Application.Handlers.ExerciseInfo
{
    public class RestoreExerciseInfoHandler : ICommandHandler<RestoreExerciseInfo>
    {
        private readonly IExerciseInfoManagementService _exerciseInfoManagementService;
        public RestoreExerciseInfoHandler(IExerciseInfoManagementService exerciseInfoManagementService)
            => _exerciseInfoManagementService = exerciseInfoManagementService;

        public async Task HandleAsync(RestoreExerciseInfo command)
            => await _exerciseInfoManagementService.RestoreAsync(command.Id);
    }
}