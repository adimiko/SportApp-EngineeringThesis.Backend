using System;

namespace Application.Commands.Account
{
    public class ChangePassword : ICommand
    {
        public Guid AccountId {get; set;}
        public string OldPassword {get; set;}
        public string NewPassword {get; set;}
        public string ConfirmNewPassword {get; set;}
    }
}