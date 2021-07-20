using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Contracts.V1;
using Api.Policies;
using Application.Commands;
using Application.Commands.BodyMeasurement;
using Application.DTOs.BodyMeasurements;
using Application.Queries;
using Application.Queries.BodyMeasurement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class BodyMeasurementController  : ApiControllerBase
    {
        public BodyMeasurementController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher) { }

        [Authorize(Policy = Policy.User)]
        [HttpGet(ApiRoutes.BodyMeasurement.GetAsync)]
        public async Task<IActionResult> GetAsync([FromRoute] GetBodyMeasurement query)
            => Json(await QueryDispatcher.DispatchAsync<BodyMeasurementDetailsDto, GetBodyMeasurement>(new GetBodyMeasurement {Id = query.Id, AccountId = AccountId}));

        [Authorize(Policy = Policy.User)]
        [HttpGet(ApiRoutes.BodyMeasurement.BrowseAsync)]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowseBodyMeasurement query)
            => Json(await QueryDispatcher.DispatchAsync<IEnumerable<BodyMeasurementDto>, BrowseBodyMeasurement>(new BrowseBodyMeasurement {AccountId = AccountId, Page = query.Page, PerPage = query.PerPage}));

        [Authorize(Policy = Policy.User)]
        [HttpPost(ApiRoutes.BodyMeasurement.CreateAsync)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBodyMeasurement command)
        {
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return Created($"{ApiRoutes.ExerciseInfo.Route}/{command.Id}", await QueryDispatcher.DispatchAsync<BodyMeasurementDetailsDto, GetBodyMeasurement>(new GetBodyMeasurement {Id = command.Id, AccountId = command.AccountId}));
        }

        [Authorize(Policy = Policy.User)]
        [HttpPut(ApiRoutes.BodyMeasurement.UpdateAsync)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateBodyMeasurement command)
        {
            command.Id = id;
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<BodyMeasurementDetailsDto, GetBodyMeasurement>(new GetBodyMeasurement {Id = command.Id, AccountId = command.AccountId}));
        }

        [Authorize(Policy = Policy.User)]
        [HttpDelete(ApiRoutes.BodyMeasurement.DeleteAsync)]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteBodyMeasurement command)
        {
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}