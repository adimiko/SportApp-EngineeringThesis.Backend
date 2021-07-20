using System;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Account;
using Application.Services.Interfaces;
using Domain.Repositories;

namespace Application.Handlers.Account
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IIdentityService _identityService;
        private readonly IAccountManagementService _accountManagementService;
        private readonly IJwtService _jwtService;
        public LoginHandler(IIdentityService identityService, IAccountManagementService accountManagementService, IJwtService jwtService)
        {
            _identityService = identityService;
            _accountManagementService = accountManagementService;
            _jwtService = jwtService;
        }
        public async Task HandleAsync(Login command)
        {
            await _identityService.LoginAsync(command.Email, command.Password);
            var account = await _accountManagementService.GetByEmailAsync(command.Email);
            await _jwtService.CreateOrUseValidToken(command.TokenId, account.Id, account.Role);
        }
    }
}