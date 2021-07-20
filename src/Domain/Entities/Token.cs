using System;
using Domain.Common;
using Domain.Errors;
using Domain.Exceptions;
using Domain.Extensions;

namespace Domain.Entities
{
    public class Token
    {
        public Guid Id {get; protected set;}
        public Guid AccountId {get; protected set;}
        public string JWT {get; protected set;}
        public DateTime Expires {get; protected set;}

        protected Token() { }

        public Token(Guid id, Guid accountId, string jwt, DateTime expires)
        {
            SetId(id);
            SetAccountId(accountId);
            SetJWT(jwt);
            SetExpires(expires);
        }
        public void SetId(Guid id)
            => _= id == Guid.Empty ? throw new InvalidIdException("Id cannot be empty.") : Id = id;
        private void SetAccountId(Guid accountId)
            => _= accountId == Guid.Empty ? throw new InvalidIdException("Account id cannot be empty.") : AccountId = accountId;

        public void SetJWT(string jwt)
            => _= string.IsNullOrWhiteSpace(jwt) ? throw new InvalidJwtException("JWT cannot be null or white space.") : JWT = jwt;

        public void SetExpires(DateTime expires)
        {
            if(expires <= DateTime.UtcNow) throw new InvalidTokenExpiresException("The expires must be greater than the current date and time.");
            Expires = expires; 
        }
    }
}