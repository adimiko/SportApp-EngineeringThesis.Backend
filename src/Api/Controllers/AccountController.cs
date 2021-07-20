using System.Threading.Tasks;
using Api.Contracts.V1;
using Application.Commands;
using Application.Commands.Account;
using Application.DTOs.Accounts;
using Application.DTOs.Tokens;
using Application.Queries;
using Application.Queries.Account;
using Application.Queries.Tokens;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher) { }

        [HttpGet(ApiRoutes.Account.GetAsync)]
        public async Task<IActionResult> GetAsync(GetAccount query)
        {
            query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<AccountDto, GetAccount>(query));
        }

        [Authorize]
        [HttpPatch(ApiRoutes.Account.ChangePasswordAsync)]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePassword command)
        {
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [Authorize]
        [HttpDelete(ApiRoutes.Account.DeleteAsync)]
        public async Task<IActionResult> DeleteAsync(DeleteAccount command)
        {
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}