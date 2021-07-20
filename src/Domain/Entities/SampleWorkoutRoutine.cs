using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SampleWorkoutRoutine : WorkoutRoutine
    {
        protected SampleWorkoutRoutine() {}
        public SampleWorkoutRoutine(Guid id, string name, IEnumerable<Exercise> exercises)
            : base(id, name, exercises) { }
    }
}