using System;
using System.Collections.Generic;
using Application.DTOs.CompletedWorkout;

namespace Application.Queries.CompletedWorkout
{
    public class BrowseCompletedWorkout : IQuery<IEnumerable<CompletedWorkoutDto>>
    {
        public Guid AccountId {get; set;}
        public int Page {get; set;} = 1;
        public int PerPage {get; set;} = 10000;
    }
}