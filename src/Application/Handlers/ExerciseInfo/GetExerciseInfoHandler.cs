using System.Threading.Tasks;
using Application.DTOs.ExerciseInfo;
using Application.Queries;
using Application.Queries.ExerciseInfo;
using Application.Services.Interfaces;

namespace Application.Handlers.ExerciseInfo
{
    public class GetExerciseInfoHandler : IQueryHandler<GetExerciseInfo, ExerciseInfoDetailsDto>
    {
        private readonly IExerciseInfoManagementService _exerciseInfoManagementService;
        public GetExerciseInfoHandler(IExerciseInfoManagementService exerciseInfoManagementService)
            => _exerciseInfoManagementService = exerciseInfoManagementService;

        public async Task<ExerciseInfoDetailsDto> HandleAsync(GetExerciseInfo query)
            => await _exerciseInfoManagementService.GetAsync(query.Id);
    }
}