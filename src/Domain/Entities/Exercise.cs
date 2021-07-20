using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Exceptions;
using Domain.Extensions;

namespace Domain.Entities
{
    public class Exercise : Entity
    {
        public Guid WorkoutRoutineId {get; protected set;}
        public Guid ExerciseInfoId {get; protected set;}
        public int Order {get; protected set;}
        public int NumberOfSets {get; protected set;}

        protected Exercise() {}
        public Exercise(Guid id, Guid workoutId, Guid exerciseInfoId, int order, int numberOfSets) 
            : base(id) 
        {
            SetExerciseInfoId(exerciseInfoId);
            SetWorkoutId(workoutId);
            SetOrder(order);
            SetNumberOfSets(numberOfSets);
        }

        private void SetExerciseInfoId(Guid exerciseInfoId)
        {
            if(exerciseInfoId.IsEmpty())
            {
                throw new InvalidIdException("Exercise info id cannot be empty.");
            }

            ExerciseInfoId = exerciseInfoId;
        }

        private void SetWorkoutId(Guid workoutRoutineId)
        {
            if(workoutRoutineId.IsEmpty())
            {
                throw new InvalidIdException("Workout id cannot be empty.");
            }

            WorkoutRoutineId = workoutRoutineId;
        }

        public void SetOrder(int order)
        {
            _=(order.IsEquelsOrBelowZero()) ? throw new InvalidOrderException("Order must be greater than zero."): Order = order;
        }

        public void SetNumberOfSets(int numberOfSets)
        {
            _= numberOfSets.IsEquelsOrBelowZero() ? throw new InvalidNumberOfSetsException("Number of sets must be greater than zero.") : NumberOfSets = numberOfSets;
        }
    }
}