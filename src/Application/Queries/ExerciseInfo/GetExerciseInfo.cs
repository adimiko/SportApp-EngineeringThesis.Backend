using System;
using Application.DTOs.ExerciseInfo;

namespace Application.Queries.ExerciseInfo
{
    public class GetExerciseInfo : IQuery<ExerciseInfoDetailsDto>
    {
        public Guid Id {get; set;}
    }
}