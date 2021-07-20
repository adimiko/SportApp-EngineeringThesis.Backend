using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.Exceptions;
using Domain.Extensions;

namespace Domain.Entities
{
    public class CompletedWorkout : AuditableEntity 
    {
        public Guid AccountId {get; protected set;}
        public string Name {get; protected set;}
        public string WorkoutNote {get; protected set;}
        public int Duration {get; protected set;}
        public DateTime Date {get; protected set;}
        public bool IsDeleted {get; protected set;}
        public DateTime? DeletedAt {get; protected set;}
        protected ISet<CompletedExercise> _exercises = new HashSet<CompletedExercise>();
        public IEnumerable<CompletedExercise> Exercises => _exercises;

        protected CompletedWorkout() {}
        public CompletedWorkout(Guid id, Guid accountId, string name, string workoutNote, int duration, DateTime date)
            : base(id)
        {
            SetAccountId(accountId);
            SetName(name);
            SetWorkoutNote(workoutNote);
            SetDuration(duration);
            SetDate(date);
        }
        private void SetAccountId(Guid accountId)
            => _= accountId.IsEmpty() ?  throw new InvalidIdException("Id cannot be empty.") : AccountId = accountId;

        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidNameException($"{this.GetType().Name} {name.GetType().Name} cannot be null or white space.");
            }

            if(Name == name) return;

            Name = name;
            Update();
        }
        public void SetWorkoutNote(string workoutNote)
        {
            if(string.IsNullOrWhiteSpace(workoutNote)) WorkoutNote = "";
            if(WorkoutNote == workoutNote) return;

            WorkoutNote = workoutNote;
            Update();
        }
        public void SetDuration(int duration)
        {
            if(duration.IsEquelsOrBelowZero())
            {
                throw new InvalidDurationException("Duration cannot be equels or below zero.");
            }
            if(Duration == duration) return;
            Duration = duration;
            Update();
        }

        public void SetDate(DateTime date)
            => Date = date.FormatToYearMonthDay();

        
        public void AddExercise(ExerciseInfo exerciseInfo)
        {
            var order = _exercises.Count + 1;
            var exercise = new CompletedExercise(Guid.NewGuid(), this.Id, exerciseInfo.Id, order);             
            _exercises.Add(exercise);
            Update();
        }

        public void AddExercise(ExerciseInfo exerciseInfo, int order)
        {
            if(order.IsEquelsOrBelowZero()) throw new Exception("Exercise order must be greater than zero.");
            
            int maxOrder = _exercises.Count + 1;
            if(maxOrder < order) throw new Exception($"Currently exercise order cannot be greater than {maxOrder}.");
            
            foreach(var exercise in _exercises)
                if(exercise.Order >= order) exercise.SetOrder(exercise.Order + 1);


            _exercises.Add(new CompletedExercise(Guid.NewGuid(), this.Id, exerciseInfo.Id, order));
            Update();
        }

        public void UpdateExercise(Guid exerciseId, int order)
        {
            var exercise = GetExercise(exerciseId);

            if(order.IsEquelsOrBelowZero()) throw new Exception("Exercise order must be greater than zero.");

            int maxOrder = _exercises.Count + 1;
            if(maxOrder < order) throw new Exception($"Currently exercise order cannot be greater than {maxOrder}.");

            var lastOrder = exercise.Order;

            if(lastOrder == order) return;

            if(lastOrder < order)
            {
                foreach(var e in _exercises.Where(x => x.Order > lastOrder && x.Order <= order)) e.SetOrder(e.Order-1);

                exercise.SetOrder(order);
            }
            else
            {
                foreach(var e in _exercises.Where(x => x.Order >= order && x.Order < lastOrder)) e.SetOrder(e.Order+1);

                exercise.SetOrder(order);
            }
            Update();
        }

        public void UpdateSet(Guid exerciseId, Guid setId, int order, int reps, float weight)
        {
            var e = _exercises.SingleOrDefault(x => x.Id == exerciseId);
            if(e == null) throw new Exception($"Exercise with id {exerciseId} does not exist.");
            e.UpdateSet(setId, order, reps, weight);
            Update();
        }



        public void Delete()
        {
            if(IsDeleted) return;
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
        private CompletedExercise GetExercise(Guid id)
        {
            var exercise = _exercises.SingleOrDefault(x => x.Id == id);
            if(exercise == null) throw new Exception($"Exercise with id {id} does not exist.");
            return exercise;
        }
    }
}