using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Errors;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class Account : AuditableEntity
    {
        public string Email {get; protected set;}
        public string Name {get; protected set;}
        public string Password {get; protected set;}
        public string Salt {get; protected set;}
        public string Role {get; protected set;}
        public bool IsDeleted {get; protected set;}
        public DateTime? DeletedAt {get; protected set;}

        protected Account() {}
        public Account(Guid id, string email, string name, string password, string salt, string role)
            :base(id)
        {
            SetEmail(email);
            SetName(name);
            SetPassword(password, salt);
            SetRole(role);
            FirstAudit();
        }

        public void SetEmail(string email)
        {
            var emailAddressAttribute = new EmailAddressAttribute();

            email = email.ToLowerInvariant();
            
            if(!emailAddressAttribute.IsValid(email)) throw new InvalidEmailException("Email is incorrect.");

            if(Email == email) return;

            Email = email;
            Update();
        }
        public void SetPassword(string password, string salt)
        {

            if(string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidPasswordException("Password cannot be empty.");
            }
            
            if(string.IsNullOrWhiteSpace(salt))
            {
                throw new InvalidSaltException("Salt cannot be empty.");
            }

            if(Password == password) return;

            Password = password;
            Salt = salt;
            Update();
        }
        private void SetName(string name)
        {
            const int minimumNameLength = 3;
            const int maximumNameLength = 20;

            if(string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidNameException("Name cannot be null or white space.");
            }

            if(name.Length < minimumNameLength)
            {
                throw new InvalidNameException($"Name must contain at least {minimumNameLength} characters.");
            }

            if(name.Length > maximumNameLength)
            {
                throw new InvalidNameException($"Name can not contain more than {maximumNameLength} characters.");
            }
            Name = name;
        }

        private void SetRole(string role)
        {
            if(role == Roles.Admin) Role = Roles.Admin;
            else Role = Roles.User;
        }

        public void Delete()
        {
            if(IsDeleted) return;
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
    }
}