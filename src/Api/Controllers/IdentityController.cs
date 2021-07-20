using System.Threading.Tasks;
using Api.Contracts.V1;
using Application.Commands;
using Application.Commands.Account;
using Application.DTOs.Tokens;
using Application.Queries;
using Application.Queries.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class IdentityController : ApiControllerBase
    {
        public IdentityController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher) { }

        [HttpPost(ApiRoutes.Identity.LoginAsync)]
        public async Task<IActionResult> LoginAsync([FromBody] Login command)
        {
            await CommandDispatcher.DispatchAsync(command);
            var x = new GetToken {TokenId = command.TokenId};
            return Json(await QueryDispatcher.DispatchAsync<TokenDto, GetToken>(x));
        }

        [HttpPost(ApiRoutes.Identity.RegisterAsync)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterAccount command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Created(ApiRoutes.Identity.Route, command.Id);
        }
    }
}