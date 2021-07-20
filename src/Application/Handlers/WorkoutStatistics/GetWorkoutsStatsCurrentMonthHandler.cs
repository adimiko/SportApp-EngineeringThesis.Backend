using System.Threading.Tasks;
using Application.DTOs.WorkoutStatistics;
using Application.Queries;
using Application.Queries.WorkoutStatistics;
using Application.Services.Interfaces;

namespace Application.Handlers.WorkoutStatistics
{
    public class GetWorkoutsStatsCurrentMonthHandler : IQueryHandler<GetWorkoutsStatsCurrentMonth, WorkoutsStatsOverTimeDto>
    {
        private readonly IWorkoutsStatsService _workoutsStatsService;

        public GetWorkoutsStatsCurrentMonthHandler(IWorkoutsStatsService workoutsStatsService)
            => _workoutsStatsService = workoutsStatsService;
        public async Task<WorkoutsStatsOverTimeDto> HandleAsync(GetWorkoutsStatsCurrentMonth query)
            => await _workoutsStatsService.GetWorkoutsStatsCurrentMonthAsync(query.AccountId);
    }
}