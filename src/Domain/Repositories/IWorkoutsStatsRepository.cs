using System;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IWorkoutsStatsRepository : IRepository
    {
        Task<GlobalWorkoutsStats> GetGlobalWorkoutsStatsAsync(Guid accountId);
        Task<WorkoutsStatsOverTime> GetWorkoutsStatsOverTimeAsync(Guid accountId, DateTime dateFrom, DateTime dateTo);
    }
}