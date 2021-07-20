using System.Threading.Tasks;
using Application.DTOs.CustomWorkoutRoutine;
using Application.Queries;
using Application.Queries.CustomWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.CustomWorkoutRoutine
{
    public class GetCustomWorkoutRoutineHandler : IQueryHandler<GetCustomWorkoutRoutine, CustomWorkoutRoutineDetailsDto>
    {
        private readonly ICustomWorkoutRoutineManagementService _customWorkoutRoutineManagementService;

        public GetCustomWorkoutRoutineHandler(ICustomWorkoutRoutineManagementService customWorkoutRoutineManagementService)
            => _customWorkoutRoutineManagementService = customWorkoutRoutineManagementService;

        public async Task<CustomWorkoutRoutineDetailsDto> HandleAsync(GetCustomWorkoutRoutine query)
            => await _customWorkoutRoutineManagementService.GetAsync(query.Id, query.AccountId);
    }
}