using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.SampleWorkoutRoutine;
using Application.DTOs.WorkoutRoutine;
using Application.Queries;
using Application.Queries.SampleWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.SampleWorkoutRoutine
{
    public class BrowseSampleWorkoutRoutineArchiveHandler : IQueryHandler<BrowseSampleWorkoutRoutineArchive, IEnumerable<SampleWorkoutRoutineDto>>
    {
        private ISampleWorkoutRoutineManagementService _sampleWorkoutRoutineManagementService;
        public BrowseSampleWorkoutRoutineArchiveHandler(ISampleWorkoutRoutineManagementService sampleWorkoutRoutineManagementService)
            => _sampleWorkoutRoutineManagementService = sampleWorkoutRoutineManagementService;
        public async Task<IEnumerable<SampleWorkoutRoutineDto>> HandleAsync(BrowseSampleWorkoutRoutineArchive query)
            => await _sampleWorkoutRoutineManagementService.BrowseArchiveAsync
            (
                query.Page,
                query.PerPage
            );
    }
}