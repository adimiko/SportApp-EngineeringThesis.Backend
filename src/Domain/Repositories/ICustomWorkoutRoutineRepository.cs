using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomWorkoutRoutineRepository : IRepository
    {
        Task<CustomWorkoutRoutine> GetAsync(Guid id);
        Task<CustomWorkoutRoutine> GetByNameAsync(string name);
        Task<IEnumerable<CustomWorkoutRoutine>> BrowseWithoutArchiveAsync(Guid accountId, int page, int perPage);
        Task<IEnumerable<CustomWorkoutRoutine>> BrowseArchiveAsync(Guid accountId, int page, int perPage);
        Task AddAsync(CustomWorkoutRoutine customWorkoutRoutine);
        Task UpdateAsync(CustomWorkoutRoutine customWorkoutRoutine);
    }
}