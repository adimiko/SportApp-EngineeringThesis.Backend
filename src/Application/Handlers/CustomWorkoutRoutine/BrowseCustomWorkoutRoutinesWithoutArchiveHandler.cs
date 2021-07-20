using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.CustomWorkoutRoutine;
using Application.Queries;
using Application.Queries.CustomWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.CustomWorkoutRoutine
{
    public class BrowseCustomWorkoutRoutinesWithoutArchiveHandler : IQueryHandler<BrowseCustomWorkoutRoutinesWithoutArchive, IEnumerable<CustomWorkoutRoutineDto>>
    {
        private readonly ICustomWorkoutRoutineManagementService _customWorkoutRoutineManagementService;
        public BrowseCustomWorkoutRoutinesWithoutArchiveHandler(ICustomWorkoutRoutineManagementService customWorkoutRoutineManagementService)
            => _customWorkoutRoutineManagementService = customWorkoutRoutineManagementService;
        public async Task<IEnumerable<CustomWorkoutRoutineDto>> HandleAsync(BrowseCustomWorkoutRoutinesWithoutArchive query)
            => await _customWorkoutRoutineManagementService.BrowseWithoutArchiveAsync
            (
                query.AccountId,
                query.Page,
                query.PerPage
            );
    }
}