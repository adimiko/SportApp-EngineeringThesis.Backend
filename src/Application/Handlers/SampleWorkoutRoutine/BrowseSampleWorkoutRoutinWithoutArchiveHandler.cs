using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.SampleWorkoutRoutine;
using Application.Queries;
using Application.Queries.SampleWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.SampleWorkoutRoutine
{
    public class BrowseSampleWorkoutRoutineWithoutArchiveHandler : IQueryHandler<BrowseSampleWorkoutRoutineWithoutArchive, IEnumerable<SampleWorkoutRoutineDto>>
    {
        private ISampleWorkoutRoutineManagementService _sampleWorkoutRoutineManagementService;
        public BrowseSampleWorkoutRoutineWithoutArchiveHandler(ISampleWorkoutRoutineManagementService sampleWorkoutRoutineManagementService)
            => _sampleWorkoutRoutineManagementService = sampleWorkoutRoutineManagementService;
        public async Task<IEnumerable<SampleWorkoutRoutineDto>> HandleAsync(BrowseSampleWorkoutRoutineWithoutArchive query)
            => await _sampleWorkoutRoutineManagementService.BrowseWithoutArchiveAsync
            (
                query.Page,
                query.PerPage
            );
    }
}