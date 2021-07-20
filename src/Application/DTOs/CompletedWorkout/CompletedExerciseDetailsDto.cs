using System;
using System.Collections.Generic;

namespace Application.DTOs.CompletedWorkout
{
    public class CompletedExerciseDetailsDto
    {
        public Guid Id {get; set;}
        public Guid ExerciseInfoId {get; set;}
        public string Name {get; set;}
        public int Order {get; set;}
        public IEnumerable<CompletedSetDetailsDto> Sets {get; set;}
    }
}