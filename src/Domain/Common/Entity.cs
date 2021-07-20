using System;
using Domain.Errors;
using Domain.Exceptions;

namespace Domain.Common
{
    public abstract class Entity
    {
        public Guid Id {get; protected set;}

        protected Entity() {}
        public Entity(Guid id)
            => SetId(id);
        private void SetId(Guid id)
            => _= id == Guid.Empty ? throw new InvalidIdException("Id cannot be empty.") : Id = id;
    }
}