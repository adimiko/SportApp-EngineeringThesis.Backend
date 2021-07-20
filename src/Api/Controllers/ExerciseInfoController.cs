using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Contracts.V1;
using Api.Policies;
using Application.Commands;
using Application.Commands.ExerciseInfo;
using Application.DTOs.ExerciseInfo;
using Application.Queries;
using Application.Queries.ExerciseInfo;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class ExerciseInfoController : ApiControllerBase
    {
        public ExerciseInfoController(ICommandDispatcher commandDispatcher,  IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher){ }

        [HttpGet(ApiRoutes.ExerciseInfo.GetAsync)]
        public async Task<IActionResult> GetAsync([FromRoute] GetExerciseInfo query)
            => Json(await QueryDispatcher.DispatchAsync<ExerciseInfoDetailsDto, GetExerciseInfo>(query));

        [HttpGet(ApiRoutes.ExerciseInfo.BrowseWithoutArchiveAsync)]
        public async Task<IActionResult> BrowseWithoutArchiveAsync([FromQuery] BrowseExerciseInfoWithoutArchive query)
            => Json(await QueryDispatcher.DispatchAsync<IEnumerable<ExerciseInfoDto>, BrowseExerciseInfoWithoutArchive>(query));

        [Authorize(Policy = Policy.Admin)]
        [HttpGet(ApiRoutes.ExerciseInfo.BrowseArchiveAsync)]
        public async Task<IActionResult> BrowseArchiveAsync([FromQuery] BrowseExerciseInfoArchive query)
            => Json(await QueryDispatcher.DispatchAsync<IEnumerable<ExerciseInfoDto>, BrowseExerciseInfoArchive>(query));

        [Authorize(Policy = Policy.Admin)]
        [HttpPost(ApiRoutes.ExerciseInfo.CreateAsync)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateExerciseInfo command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Created($"{ApiRoutes.ExerciseInfo.Route}/{command.Id}", await QueryDispatcher.DispatchAsync<ExerciseInfoDetailsDto, GetExerciseInfo>(new GetExerciseInfo {Id = command.Id}));
        }

        [Authorize(Policy = Policy.Admin)]
        [HttpPut(ApiRoutes.ExerciseInfo.UpdateAsync)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateExerciseInfo command)
        {
            command.Id = id;
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<ExerciseInfoDetailsDto, GetExerciseInfo>(new GetExerciseInfo {Id = command.Id}));
        }
        [Authorize(Policy = Policy.Admin)]
        [HttpPatch(ApiRoutes.ExerciseInfo.ArchiveAsync)]
        public async Task<IActionResult> ArchiveAsync([FromRoute] ArchiveExerciseInfo command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<ExerciseInfoDetailsDto, GetExerciseInfo>(new GetExerciseInfo {Id = command.Id}));
        }

        [Authorize(Policy = Policy.Admin)]
        [HttpPatch(ApiRoutes.ExerciseInfo.RestoreAsync)]
        public async Task<IActionResult> RestoreAsync([FromRoute] RestoreExerciseInfo command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<ExerciseInfoDetailsDto, GetExerciseInfo>(new GetExerciseInfo {Id = command.Id}));
        }
    }
}