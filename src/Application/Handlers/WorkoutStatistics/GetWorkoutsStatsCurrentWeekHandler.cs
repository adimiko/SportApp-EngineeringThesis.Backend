using System.Threading.Tasks;
using Application.DTOs.WorkoutStatistics;
using Application.Queries;
using Application.Queries.WorkoutStatistics;
using Application.Services.Interfaces;

namespace Application.Handlers.WorkoutStatistics
{
    public class GetWorkoutsStatsCurrentWeekHandler : IQueryHandler<GetWorkoutsStatsCurrentWeek, WorkoutsStatsOverTimeDto>
    {
        private readonly IWorkoutsStatsService _workoutsStatsService;

        public GetWorkoutsStatsCurrentWeekHandler(IWorkoutsStatsService workoutsStatsService)
            => _workoutsStatsService = workoutsStatsService;
        public async Task<WorkoutsStatsOverTimeDto> HandleAsync(GetWorkoutsStatsCurrentWeek query)
            => await _workoutsStatsService.GetWorkoutsStatsCurrentWeekAsync(query.AccountId);
    }
}