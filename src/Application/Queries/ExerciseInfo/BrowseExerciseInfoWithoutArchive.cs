using System.Collections.Generic;
using Application.DTOs.ExerciseInfo;

namespace Application.Queries.ExerciseInfo
{
    public class BrowseExerciseInfoWithoutArchive : IQuery<IEnumerable<ExerciseInfoDto>>
    {
        public int Page {get; set;} = 1;
        public int PerPage {get; set;} = 10000;
    }
}