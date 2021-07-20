using System;
using System.Collections.Generic;
using Application.DTOs.CustomWorkoutRoutine;

namespace Application.Queries.CustomWorkoutRoutine
{
    public class BrowseCustomWorkoutRoutinesWithoutArchive : IQuery<IEnumerable<CustomWorkoutRoutineDto>>
    {
        public Guid AccountId {get; set;}
        public int Page {get; set;} = 1;
        public int PerPage {get; set;} = 10000;
    }
}