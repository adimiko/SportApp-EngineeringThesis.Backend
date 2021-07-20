using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.CompletedWorkout;
using Application.DTOs.CompletedWorkout;

namespace Application.Services.Interfaces
{
    public interface ICompletedWorkoutManagementService : IService
    {
        Task<CompletedWorkoutDetailsDto> GetAsync(Guid id, Guid accountId);
        Task<IEnumerable<CompletedWorkoutDto>> BrowseAsync(Guid accountId, int page, int perPage);
        Task CreateAsync(Guid id, Guid accountId, string name, string workoutNote, int duration, DateTime date, IEnumerable<CreateCompletedExercise> exercises);
        Task DeleteAsync(Guid id, Guid accountId);
    }
}