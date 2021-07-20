using System;

namespace Application.Commands.Account
{
    public class DeleteAccount : ICommand
    {
        public Guid AccountId {get; set;}
    }
}