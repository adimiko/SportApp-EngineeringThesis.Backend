using System;

namespace Application.DTOs.CompletedWorkout
{
    public class CompletedSetDetailsDto
    {
        public Guid Id {get; set;}
        public int Order {get; set;}
        public int Reps {get; set;}
        public float Weight {get; set;}
    }
}