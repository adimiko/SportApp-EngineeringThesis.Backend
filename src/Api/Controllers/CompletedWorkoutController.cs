using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Contracts.V1;
using Api.Policies;
using Application.Commands;
using Application.Commands.CompletedWorkout;
using Application.DTOs.CompletedWorkout;
using Application.Queries;
using Application.Queries.CompletedWorkout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Policy = Policy.User)]
    public class CompletedWorkoutController : ApiControllerBase
    {
        public CompletedWorkoutController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher) { }

        [HttpGet(ApiRoutes.CompletedWorkout.GetAsync)]
        public async Task<IActionResult> GetAsync([FromRoute] GetCompletedWorkout query)
        {
             query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<CompletedWorkoutDetailsDto, GetCompletedWorkout>(query));
        }

        [HttpGet(ApiRoutes.CompletedWorkout.BrowseAsync)]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowseCompletedWorkout query)
        {
            query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<IEnumerable<CompletedWorkoutDto>, BrowseCompletedWorkout>(query));
        }

        [HttpPost(ApiRoutes.CompletedWorkout.SaveAsync)]
        public async Task<IActionResult> SaveAsync([FromBody] CreateCompletedWorkout command)
        {
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return Created($"{ApiRoutes.CompletedWorkout.SaveAsync}/{command.Id}", await QueryDispatcher.DispatchAsync<CompletedWorkoutDetailsDto, GetCompletedWorkout>(new GetCompletedWorkout {Id = command.Id, AccountId = AccountId}));
        }

        [HttpDelete(ApiRoutes.CompletedWorkout.DeleteAsync)]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteCompletedWorkout command)
        {
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}