using System.Threading.Tasks;
using Application.DTOs.WorkoutStatistics;
using Application.Queries;
using Application.Queries.WorkoutStatistics;
using Application.Services.Interfaces;

namespace Application.Handlers.WorkoutStatistics
{
    public class GetGlobalWorkoutsStatsHandler : IQueryHandler<GetGlobalWorkoutsStats, GlobalWorkoutsStatsDto>
    {
        private readonly IWorkoutsStatsService _workoutsStatsService;

        public GetGlobalWorkoutsStatsHandler(IWorkoutsStatsService workoutsStatsService)
            => _workoutsStatsService = workoutsStatsService;
        public async Task<GlobalWorkoutsStatsDto> HandleAsync(GetGlobalWorkoutsStats query)
            => await _workoutsStatsService.GetGlobalWorkoutsStatsAsync(query.AccountId);
    }
}