using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.CustomWorkoutRoutine;
using Application.Queries;
using Application.Queries.CustomWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.CustomWorkoutRoutine
{
    public class BrowseCustomWorkoutRoutinesArchiveHandler : IQueryHandler<BrowseCustomWorkoutRoutinesArchive, IEnumerable<CustomWorkoutRoutineDto>>
    {
        private readonly ICustomWorkoutRoutineManagementService _customWorkoutRoutineManagementService;
        public BrowseCustomWorkoutRoutinesArchiveHandler(ICustomWorkoutRoutineManagementService customWorkoutRoutineManagementService)
            => _customWorkoutRoutineManagementService = customWorkoutRoutineManagementService;
        public async Task<IEnumerable<CustomWorkoutRoutineDto>> HandleAsync(BrowseCustomWorkoutRoutinesArchive query)
            => await _customWorkoutRoutineManagementService.BrowseArchiveAsync
            (
                query.AccountId,
                query.Page,
                query.PerPage
            );
    }
}