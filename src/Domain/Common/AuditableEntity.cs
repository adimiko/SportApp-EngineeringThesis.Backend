using System;

namespace Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt {get; protected set;}
        public DateTime UpdatedAt {get; protected set;}

        protected AuditableEntity(){}
        public AuditableEntity(Guid id):base(id) {}

        protected void FirstAudit()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        protected void Update()
            => UpdatedAt = DateTime.UtcNow;
    }
}