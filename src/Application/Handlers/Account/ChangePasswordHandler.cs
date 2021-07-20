using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Account;
using Application.Services.Interfaces;

namespace Application.Handlers.Account
{
    public class ChangePasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IAccountManagementService _accountManagementService;

        public ChangePasswordHandler(IAccountManagementService accountManagementService)
            => _accountManagementService = accountManagementService;
        public async Task HandleAsync(ChangePassword command)
            => await _accountManagementService.ChangePasswordAsync
            (
                command.AccountId,
                command.OldPassword,
                command.NewPassword,
                command.ConfirmNewPassword
            );
    }
}