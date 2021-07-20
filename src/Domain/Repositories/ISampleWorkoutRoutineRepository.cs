using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISampleWorkoutRoutineRepository : IRepository
    {
        Task<SampleWorkoutRoutine> GetAsync(Guid id);
        Task<SampleWorkoutRoutine> GetByNameAsync(string name);
        Task<IEnumerable<SampleWorkoutRoutine>> BrowseWithoutArchiveAsync(int page, int perPage);
        Task<IEnumerable<SampleWorkoutRoutine>> BrowseArchiveAsync(int page, int perPage);
        Task AddAsync(SampleWorkoutRoutine sampleWorkoutRoutine);
        Task UpdateAsync(SampleWorkoutRoutine sampleWorkoutRoutine);
    }
}