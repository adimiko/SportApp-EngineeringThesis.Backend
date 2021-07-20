using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Contracts.V1;
using Api.Policies;
using Application.Commands;
using Application.Commands.CustomWorkoutRoutine;
using Application.DTOs.CustomWorkoutRoutine;
using Application.Queries;
using Application.Queries.CustomWorkoutRoutine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Policy = Policy.User)]
    public class CustomWorkoutRoutineController : ApiControllerBase
    {
        public CustomWorkoutRoutineController(ICommandDispatcher commandDispatcher,  IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher){ }


        [HttpGet(ApiRoutes.CustomWorkoutRoutine.GetAsync)]
        public async Task<IActionResult> GetAsync([FromRoute] GetCustomWorkoutRoutine query)
         {
             query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<CustomWorkoutRoutineDetailsDto, GetCustomWorkoutRoutine>(query));
         }

        [HttpGet(ApiRoutes.CustomWorkoutRoutine.BrowseWithoutArchiveAsync)]
        public async Task<IActionResult> BrowseWithoutArchiveAsync([FromQuery] BrowseCustomWorkoutRoutinesWithoutArchive query)
        {
            query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<IEnumerable<CustomWorkoutRoutineDto>, BrowseCustomWorkoutRoutinesWithoutArchive>(query));
        }

        [HttpGet(ApiRoutes.CustomWorkoutRoutine.BrowseArchiveAsync)]
        public async Task<IActionResult> BrowseArchiveAsync([FromQuery] BrowseCustomWorkoutRoutinesArchive query)
        {
            query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<IEnumerable<CustomWorkoutRoutineDto>, BrowseCustomWorkoutRoutinesArchive>(query));
        }

        [HttpPost(ApiRoutes.CustomWorkoutRoutine.CreateAsync)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCustomWorkoutRoutine command)
        {
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return Created($"{ApiRoutes.ExerciseInfo.Route}/{command.Id}", await QueryDispatcher.DispatchAsync<CustomWorkoutRoutineDetailsDto, GetCustomWorkoutRoutine>(new GetCustomWorkoutRoutine {Id = command.Id, AccountId = AccountId}));
        }

        [Authorize(Policy = Policy.Admin)]
        [HttpPut(ApiRoutes.CustomWorkoutRoutine.UpdateAsync)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateCustomWorkoutRoutine command)
        {
            command.Id = id;
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<CustomWorkoutRoutineDetailsDto, GetCustomWorkoutRoutine>(new GetCustomWorkoutRoutine {Id = command.Id}));
        }

        [HttpPatch(ApiRoutes.CustomWorkoutRoutine.ArchiveAsync)]
        public async Task<IActionResult> ArchiveAsync([FromRoute] ArchiveCustomWorkoutRoutine command)
        {
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<CustomWorkoutRoutineDetailsDto, GetCustomWorkoutRoutine>(new GetCustomWorkoutRoutine {Id = command.Id, AccountId = command.AccountId}));
        }

        [HttpPatch(ApiRoutes.CustomWorkoutRoutine.RestoreAsync)]
        public async Task<IActionResult> RestoreAsync([FromRoute] RestoreCustomWorkoutRoutine command)
        {
            command.AccountId = AccountId;
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<CustomWorkoutRoutineDetailsDto, GetCustomWorkoutRoutine>(new GetCustomWorkoutRoutine {Id = command.Id, AccountId = command.AccountId}));
        }
    }
}