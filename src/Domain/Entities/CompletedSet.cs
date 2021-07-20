using System;
using Domain.Common;
using Domain.Exceptions;
using Domain.Extensions;

namespace Domain.Entities
{
    public class CompletedSet : Entity
    {
        public Guid CompletedExerciseId {get; protected set;}
        public int Order {get; protected set;}
        public int Reps {get; protected set;}
        public float Weight {get; protected set;}

        protected CompletedSet() {}
        public CompletedSet(Guid id, Guid exerciseId, int order, int reps, float weight)
            : base(id)
        {
            SetExerciseId(exerciseId);
            SetOrder(order);
            SetReps(reps);
            SetWeight(weight);
        }
        private void SetExerciseId(Guid completedExerciseId)
        {
            if(completedExerciseId.IsEmpty())
            {
                throw new InvalidIdException("Exercise id cannot be empty.");
            }

            CompletedExerciseId = completedExerciseId;
        }
        public void SetOrder(int order)
        => _=(order.IsEquelsOrBelowZero()) ? throw new InvalidOrderException("Order must be greater than zero."): Order = order;
        public void SetReps(int reps)
        => _=(reps.IsEquelsOrBelowZero()) ? throw new InvalidRepsException("Reps must be greater than zero."): Reps = reps;  
    
        public void SetWeight(float weight)
        => _=(weight.IsEquelsOrBelowZero()) ? throw new InvalidWeightException("Weight must be greater than zero."): Weight = weight;
    }
}