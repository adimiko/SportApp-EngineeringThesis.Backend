using System.Threading.Tasks;
using Application.DTOs.WorkoutStatistics;
using Application.Queries;
using Application.Queries.WorkoutStatistics;
using Application.Services.Interfaces;

namespace Application.Handlers.WorkoutStatistics
{
    public class GetWorkoutsStatsCurrentYearHandler : IQueryHandler<GetWorkoutsStatsCurrentYear, WorkoutsStatsOverTimeDto>
    {
        private readonly IWorkoutsStatsService _workoutsStatsService;

        public GetWorkoutsStatsCurrentYearHandler(IWorkoutsStatsService workoutsStatsService)
            => _workoutsStatsService = workoutsStatsService;
        public async Task<WorkoutsStatsOverTimeDto> HandleAsync(GetWorkoutsStatsCurrentYear query)
            => await _workoutsStatsService.GetWorkoutsStatsCurrentYearAsync(query.AccountId);
    }
}