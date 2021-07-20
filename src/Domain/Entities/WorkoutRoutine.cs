using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.Exceptions;
using Domain.Extensions;

namespace Domain.Entities
{
    public abstract class WorkoutRoutine : AuditableEntity
    {
        
        public string Name {get; protected set;}
        public bool IsArchived {get; protected set;}
        public DateTime? ArchiveDate {get; protected set;}

        private ISet<Exercise> _exercises = new HashSet<Exercise>();
        public IEnumerable<Exercise> Exercises => _exercises;

        protected WorkoutRoutine() {}
        public WorkoutRoutine(Guid id, string name, IEnumerable<Exercise> exercises)
            : base(id)
        {
            SetName(name);
            SetExercises(exercises);
            FirstAudit();
        }
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

        public void SetExercises(IEnumerable<Exercise> exercises)
        {
            exercises = exercises.OrderBy(x => x.Order);
            _exercises.Clear();
            for(var i=1; i <= exercises.Count(); i++)
            {
                var exercise = exercises.ElementAt(i-1);
                if(exercise.Order != i)
                {
                    throw new InvalidOrderException("Order is incorrect.");
                }
                _exercises.Add(new Exercise(Guid.NewGuid(), this.Id , exercise.ExerciseInfoId, exercise.Order, exercise.NumberOfSets));
            }
        }

        public void Archive()
        {
            if(IsArchived) return;
            IsArchived = true;
            ArchiveDate = DateTime.UtcNow;
        }

        public void Restore()
        {
            if(!IsArchived) return;
            IsArchived = false;
            ArchiveDate = null;
        }
    }
}