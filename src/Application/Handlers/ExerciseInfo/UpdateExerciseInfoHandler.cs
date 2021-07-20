using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.ExerciseInfo;
using Application.Services.Interfaces;

namespace Application.Handlers.ExerciseInfo
{
    public class UpdateExerciseInfoHandler : ICommandHandler<UpdateExerciseInfo>
    {
        private readonly IExerciseInfoManagementService _exerciseInfoManagementService;
        public UpdateExerciseInfoHandler(IExerciseInfoManagementService exerciseInfoManagementService)
            => _exerciseInfoManagementService = exerciseInfoManagementService;

        public async Task HandleAsync(UpdateExerciseInfo command)
            => await _exerciseInfoManagementService.UpdateAsync(command.Id, command.Name, command.Description);
    }
}