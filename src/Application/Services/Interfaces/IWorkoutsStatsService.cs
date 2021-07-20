using System;
using System.Threading.Tasks;
using Application.DTOs.WorkoutStatistics;

namespace Application.Services.Interfaces
{
    public interface IWorkoutsStatsService : IService
    {
        Task<GlobalWorkoutsStatsDto> GetGlobalWorkoutsStatsAsync(Guid accountId);
        Task<WorkoutsStatsOverTimeDto> GetWorkoutsStatsCurrentWeekAsync(Guid accountId);
        Task<WorkoutsStatsOverTimeDto> GetWorkoutsStatsCurrentMonthAsync(Guid accountId);
        Task<WorkoutsStatsOverTimeDto> GetWorkoutsStatsCurrentYearAsync(Guid accountId);
        Task<WorkoutsStatsOverTimeDto> GetWorkoutsStatsOverTimeAsync(Guid accountId, DateTime dateFrom, DateTime dateTo);
    }
}