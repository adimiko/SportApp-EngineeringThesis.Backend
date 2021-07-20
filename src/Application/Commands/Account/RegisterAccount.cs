using System;
using Domain.Common;

namespace Application.Commands.Account
{
    public class RegisterAccount : ICommand
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public string Email {get; set;}
        public string Name {get; set;}
        public string Password {get; set;}
        public string ConfirmPassword {get; set;}
        public string Role {get; set;} = Roles.User;
    }
}