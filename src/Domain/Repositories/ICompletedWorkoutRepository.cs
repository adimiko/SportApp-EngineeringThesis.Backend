using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICompletedWorkoutRepository : IRepository
    {
        Task<CompletedWorkout> GetAsync(Guid id);
        Task<IEnumerable<CompletedWorkout>> BrowseAsync(Guid accountId, int page, int perPage);
        Task AddAsync(CompletedWorkout completedWorkout);
        Task UpdateAsync(CompletedWorkout completedWorkout);
        Task DeleteAsync(CompletedWorkout completedWorkout);
    }
}