using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IExerciseInfoRepository : IRepository
    {
        Task<ExerciseInfo> GetAsync(Guid id);
        Task<ExerciseInfo> GetByNameAsync(string name);
        Task<IEnumerable<ExerciseInfo>> BrowseWithoutArchiveAsync(int page, int perPage);
        Task<IEnumerable<ExerciseInfo>> BrowseArchiveAsync(int page, int perPage);
        Task AddAsync(ExerciseInfo exerciseInfo);  
        Task UpdateAsync(ExerciseInfo exerciseInfo);  
    }
}