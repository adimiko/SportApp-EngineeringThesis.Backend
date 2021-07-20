using System;
using Application.DTOs.CustomWorkoutRoutine;

namespace Application.Queries.CustomWorkoutRoutine
{
    public class GetCustomWorkoutRoutine : IQuery<CustomWorkoutRoutineDetailsDto>
    {
        public Guid Id {get; set;}
        public Guid AccountId {get; set;}
    }
}