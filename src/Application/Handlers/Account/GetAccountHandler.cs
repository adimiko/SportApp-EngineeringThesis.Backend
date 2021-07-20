using System.Threading.Tasks;
using Application.DTOs.Accounts;
using Application.Queries;
using Application.Queries.Account;
using Application.Services.Interfaces;

namespace Application.Handlers.Account
{
    public class GetAccountHandler : IQueryHandler<GetAccount, AccountDto>
    {
        private readonly IAccountManagementService _accountManagementService;

        public GetAccountHandler(IAccountManagementService accountManagementService)
            => _accountManagementService = accountManagementService;
        public async Task<AccountDto> HandleAsync(GetAccount query)
            => await _accountManagementService.GetAsync(query.AccountId);
    }
}