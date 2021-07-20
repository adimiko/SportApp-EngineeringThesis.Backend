using System;
using Application.DTOs.CompletedWorkout;

namespace Application.Queries.CompletedWorkout
{
    public class GetCompletedWorkout : IQuery<CompletedWorkoutDetailsDto>
    {
        public Guid Id {get; set;}
        public Guid AccountId {get; set;}
    }
}