using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Account;
using Application.Services.Interfaces;

namespace Application.Handlers.Account
{
    public class RegisterAccountHandler : ICommandHandler<RegisterAccount>
    {
        private readonly IIdentityService _identityService;
        public RegisterAccountHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task HandleAsync(RegisterAccount command)
        {
            await _identityService.RegisterAsync(
                command.Id,
                command.Email,
                command.Name,
                command.Password,
                command.ConfirmPassword,
                command.Role
            );
        }
    }
}