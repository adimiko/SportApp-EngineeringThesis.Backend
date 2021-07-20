using System;
using Domain.Common;
using Domain.Errors;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class ExerciseInfo: AuditableEntity
    {
        public string Name {get; protected set;}
        public string Description {get; protected set;}
        public bool IsArchived {get; protected set;}
        public DateTime? ArchiveDate {get; protected set;}

        protected ExerciseInfo() {}
        public ExerciseInfo(Guid id, string name, string description) 
        : base(id)
        {
            SetName(name);
            SetDescription(description);
            FirstAudit();
        }
        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new InvalidNameException("Name cannot be null or white space.");
            if(Name == name) return;

            Name = name;
            Update();
        }

        public void SetDescription(string description)
        {
            if(string.IsNullOrWhiteSpace(description)) description = "";
            if(Description == description) return;
            
            Description = description;
            Update();
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