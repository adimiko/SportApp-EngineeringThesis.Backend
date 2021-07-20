using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.WorkoutRoutine;
using Application.DTOs.SampleWorkoutRoutine;
using Application.DTOs.WorkoutRoutine;

namespace Application.Services.Interfaces
{
    public interface ISampleWorkoutRoutineManagementService : IService
    {
        Task<SampleWorkoutRoutineDetailsDto> GetAsync(Guid id);
        Task<IEnumerable<SampleWorkoutRoutineDto>> BrowseWithoutArchiveAsync(int page, int perPage);
        Task<IEnumerable<SampleWorkoutRoutineDto>> BrowseArchiveAsync(int page, int perPage);
        Task CreateAsync(Guid id, string name, IEnumerable<CreateExercise> exercises);
        Task UpdateAsync(Guid id, string name, IEnumerable<UpdateExercise> exercises);
        Task ArchiveAsync(Guid id);
        Task RestoreAsync(Guid id);
    }
}