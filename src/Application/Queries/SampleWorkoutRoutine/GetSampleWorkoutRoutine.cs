using System;
using Application.DTOs.SampleWorkoutRoutine;

namespace Application.Queries.SampleWorkoutRoutine
{
    public class GetSampleWorkoutRoutine : IQuery<SampleWorkoutRoutineDetailsDto>
    {
        public Guid Id {get; set;}
    }
}