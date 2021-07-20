using System;

namespace Application.Commands.Account
{
    public class Login : ICommand
    {
        public Guid TokenId { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }

    }
}