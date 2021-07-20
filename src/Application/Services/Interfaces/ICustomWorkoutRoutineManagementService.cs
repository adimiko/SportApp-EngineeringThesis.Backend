using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.WorkoutRoutine;
using Application.DTOs.CustomWorkoutRoutine;

namespace Application.Services.Interfaces
{
    public interface ICustomWorkoutRoutineManagementService : IService
    {
        Task<CustomWorkoutRoutineDetailsDto> GetAsync(Guid id, Guid accountId);
        Task<IEnumerable<CustomWorkoutRoutineDto>> BrowseWithoutArchiveAsync(Guid accountId, int page, int perPage);
        Task<IEnumerable<CustomWorkoutRoutineDto>> BrowseArchiveAsync(Guid accountId, int page, int perPage);
        Task CreateAsync(Guid id, Guid accountId, string name, IEnumerable<CreateExercise> exercises);
        Task UpdateAsync(Guid id, string name, IEnumerable<UpdateExercise> exercises);
        Task ArchiveAsync(Guid id, Guid accountId);
        Task RestoreAsync(Guid id, Guid accountId);
    }
}