using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.ExerciseInfo;
using Application.Services.Interfaces;

namespace Application.Handlers.ExerciseInfo
{
    public class CreateExerciseInfoHandler : ICommandHandler<CreateExerciseInfo>
    {
        private readonly IExerciseInfoManagementService _exerciseInfoManagementService;
        public CreateExerciseInfoHandler(IExerciseInfoManagementService exerciseInfoManagementService)
        {
            _exerciseInfoManagementService = exerciseInfoManagementService;
        }

        public async Task HandleAsync(CreateExerciseInfo command)
        {
            await _exerciseInfoManagementService.CreateAsync(
                command.Id,
                command.Name,
                command.Description
            );
        }
    }
}