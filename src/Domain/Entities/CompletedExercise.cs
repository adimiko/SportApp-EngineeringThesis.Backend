using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.Exceptions;
using Domain.Extensions;

namespace Domain.Entities
{
    public class CompletedExercise : Entity
    {
        protected ISet<CompletedSet> _sets = new HashSet<CompletedSet>();
        public Guid CompletedWorkoutId {get; protected set;}
        public Guid ExerciseInfoId {get; protected set;}
        public int Order {get; protected set;}
        public IEnumerable<CompletedSet> Sets => _sets;

        protected CompletedExercise() {}
        public CompletedExercise(Guid id, Guid workoutId, Guid exerciseInfoId, int order) 
            : base(id) 
        {
            SetExerciseInfoId(exerciseInfoId);
            SetCompletedWorkoutId(workoutId);
            SetOrder(order);
        }

        private void SetExerciseInfoId(Guid exerciseInfoId)
        {
            if(exerciseInfoId.IsEmpty())
            {
                throw new InvalidIdException("Exercise info id cannot be empty.");
            }

            ExerciseInfoId = exerciseInfoId;
        }

        private void SetCompletedWorkoutId(Guid workoutId)
        {
            if(workoutId.IsEmpty())
            {
                throw new InvalidIdException("Completed Workout id cannot be empty.");
            }

            CompletedWorkoutId = workoutId;
        }

        public void SetOrder(int order)
        {
            _=(order.IsEquelsOrBelowZero()) ? throw new InvalidOrderException("Order must be greater than zero."): Order = order;
        }

        public void AddSet(int reps, float weight)
        {
            var order = _sets.Count + 1;

            var set = new CompletedSet(Guid.NewGuid(), this.Id, order, reps, weight);

            _sets.Add(set);
        }

        public void UpdateSet(Guid setId, int order, int reps, float weight)
        {
            var set = GetSet(setId);

            int maxOrder = _sets.Count + 1;
            if(maxOrder < order) throw new Exception($"Currently set order cannot be greater than {maxOrder}.");

            set.SetOrder(order);
            set.SetReps(reps);
            set.SetWeight(weight);
            
            var lastOrder = set.Order;
            if(lastOrder == order) return;


            if(lastOrder < order)
            {
                foreach(var e in _sets.Where(x => x.Order > lastOrder && x.Order <= order)) e.SetOrder(e.Order-1);

                set.SetOrder(order);
            }
            else
            {
                foreach(var e in _sets.Where(x => x.Order >= order && x.Order < lastOrder)) e.SetOrder(e.Order+1);
                
                set.SetOrder(order);
            }
        }

        private CompletedSet GetSet(Guid id)
        {
            var set = _sets.SingleOrDefault(x => x.Id == id);
            if(set == null) throw new Exception($"Set with id {id} does not exist.");
            return set;
        }
    }
}