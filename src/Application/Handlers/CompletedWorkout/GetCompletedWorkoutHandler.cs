using System.Threading.Tasks;
using Application.DTOs.CompletedWorkout;
using Application.Queries;
using Application.Queries.CompletedWorkout;
using Application.Services.Interfaces;

namespace Application.Handlers.CompletedWorkout
{
    public class GetCompletedWorkoutHandler : IQueryHandler<GetCompletedWorkout, CompletedWorkoutDetailsDto>
    {
        private readonly ICompletedWorkoutManagementService _completedWorkoutManagementService;
        public GetCompletedWorkoutHandler(ICompletedWorkoutManagementService completedWorkoutManagementService)
            => _completedWorkoutManagementService = completedWorkoutManagementService;
        public async Task<CompletedWorkoutDetailsDto> HandleAsync(GetCompletedWorkout query)
            => await _completedWorkoutManagementService.GetAsync
            (
                query.Id,
                query.AccountId
            );
    }
}