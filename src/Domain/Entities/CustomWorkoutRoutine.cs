using System;
using System.Collections.Generic;
using Domain.Exceptions;
using Domain.Extensions;

namespace Domain.Entities
{
    public class CustomWorkoutRoutine : WorkoutRoutine
    {
        public Guid AccountId {get; protected set;}
        protected CustomWorkoutRoutine() {}
        public CustomWorkoutRoutine(Guid id, Guid accountId, string name, IEnumerable<Exercise> exercises)
            : base(id, name, exercises)
        {
            SetAccountId(accountId);
        }

        private void SetAccountId(Guid accountId)
            => _= accountId.IsEmpty() ?  throw new InvalidIdException("Id cannot be empty.") : AccountId = accountId;
        
    }
}