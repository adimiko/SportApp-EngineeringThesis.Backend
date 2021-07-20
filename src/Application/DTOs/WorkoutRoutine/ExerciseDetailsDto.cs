using System;

namespace Application.DTOs.WorkoutRoutine
{
    public class ExerciseDetailsDto
    {
        public Guid Id {get; set;}
        public Guid ExerciseInfoId {get; set;}
        public string Name {get; set;}
        public int Order {get; set;}
        public int NumberOfSets {get; protected set;}
    }
}