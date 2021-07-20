using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.ExerciseInfo;

namespace Application.Services.Interfaces
{
    public interface IExerciseInfoManagementService : IService
    {
        Task<ExerciseInfoDetailsDto> GetAsync(Guid id);
        Task<IEnumerable<ExerciseInfoDto>> BrowseWithoutArchiveAsync(int page, int perPage);
        Task<IEnumerable<ExerciseInfoDto>> BrowseArchiveAsync(int page, int perPage);
        Task CreateAsync(Guid id, string name, string description);
        Task UpdateAsync(Guid id, string name, string description);
        Task ArchiveAsync(Guid id);
        Task RestoreAsync(Guid id);
    }
}