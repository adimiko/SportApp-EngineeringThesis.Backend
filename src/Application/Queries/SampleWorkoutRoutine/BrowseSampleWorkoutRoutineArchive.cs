using System.Collections.Generic;
using Application.DTOs.SampleWorkoutRoutine;

namespace Application.Queries.SampleWorkoutRoutine
{
    public class BrowseSampleWorkoutRoutineArchive : IQuery<IEnumerable<SampleWorkoutRoutineDto>>
    {
        public int Page {get; set;} = 1;
        public int PerPage {get; set;} = 10000;
    }
}