using System.Threading.Tasks;
using Application.DTOs.SampleWorkoutRoutine;
using Application.DTOs.WorkoutRoutine;
using Application.Queries;
using Application.Queries.SampleWorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Handlers.SampleWorkoutRoutine
{
    public class GetSampleWorkoutRoutineHandler : IQueryHandler<GetSampleWorkoutRoutine, SampleWorkoutRoutineDetailsDto>
    {
        private readonly ISampleWorkoutRoutineManagementService _sampleWorkoutRoutineManagementService;
        public GetSampleWorkoutRoutineHandler(ISampleWorkoutRoutineManagementService sampleWorkoutRoutineManagementService)
            => _sampleWorkoutRoutineManagementService = sampleWorkoutRoutineManagementService;
        public async Task<SampleWorkoutRoutineDetailsDto> HandleAsync(GetSampleWorkoutRoutine query)
            => await _sampleWorkoutRoutineManagementService.GetAsync(query.Id);
    }
}