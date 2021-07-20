using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Account;
using Application.Services.Interfaces;

namespace Application.Handlers.Account
{
    public class DeleteAccountHandler : ICommandHandler<DeleteAccount>
    {        
        private readonly IAccountManagementService _accountManagementService;
        public DeleteAccountHandler(IAccountManagementService accountManagementService)
            => _accountManagementService = accountManagementService;
        public async Task HandleAsync(DeleteAccount command)
            => await _accountManagementService.DeleteAsync(command.AccountId);
    }
}