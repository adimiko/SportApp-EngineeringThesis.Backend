using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Contracts.V1;
using Api.Policies;
using Application.Commands;
using Application.Commands.SampleWorkoutRoutine;
using Application.DTOs.SampleWorkoutRoutine;
using Application.Queries;
using Application.Queries.SampleWorkoutRoutine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Authorize]
    public class SampleWorkoutRoutineController : ApiControllerBase
    {
        public SampleWorkoutRoutineController(ICommandDispatcher commandDispatcher,  IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher){ }


        [HttpGet(ApiRoutes.SampleWorkoutRoutine.GetAsync)]
        public async Task<IActionResult> GetAsync([FromRoute] GetSampleWorkoutRoutine query)
            => Json(await QueryDispatcher.DispatchAsync<SampleWorkoutRoutineDetailsDto, GetSampleWorkoutRoutine>(query));

        [HttpGet(ApiRoutes.SampleWorkoutRoutine.BrowseWithoutArchiveAsync)]
        public async Task<IActionResult> BrowseWithoutArchiveAsync([FromQuery] BrowseSampleWorkoutRoutineWithoutArchive query)
            => Json(await QueryDispatcher.DispatchAsync<IEnumerable<SampleWorkoutRoutineDto>, BrowseSampleWorkoutRoutineWithoutArchive>(query));
            
        [Authorize(Policy = Policy.Admin)]
        [HttpGet(ApiRoutes.SampleWorkoutRoutine.BrowseArchiveAsync)]
        public async Task<IActionResult> BrowseArchiveAsync([FromQuery] BrowseSampleWorkoutRoutineArchive query)
            => Json(await QueryDispatcher.DispatchAsync<IEnumerable<SampleWorkoutRoutineDto>, BrowseSampleWorkoutRoutineArchive>(query));
        
        [Authorize(Policy = Policy.Admin)]
        [HttpPost(ApiRoutes.SampleWorkoutRoutine.CreateAsync)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSampleWorkoutRoutine command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Created($"{ApiRoutes.ExerciseInfo.Route}/{command.Id}", await QueryDispatcher.DispatchAsync<SampleWorkoutRoutineDetailsDto, GetSampleWorkoutRoutine>(new GetSampleWorkoutRoutine {Id = command.Id}));
        }


        [Authorize(Policy = Policy.Admin)]
        [HttpPut(ApiRoutes.SampleWorkoutRoutine.UpdateAsync)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateSampleWorkoutRoutine command)
        {
            command.Id = id;
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<SampleWorkoutRoutineDetailsDto, GetSampleWorkoutRoutine>(new GetSampleWorkoutRoutine {Id = command.Id}));
        }
        
        [Authorize(Policy = Policy.Admin)]
        [HttpPatch(ApiRoutes.SampleWorkoutRoutine.ArchiveAsync)]
        public async Task<IActionResult> ArchiveAsync([FromRoute] ArchiveSampleWorkoutRoutine command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<SampleWorkoutRoutineDetailsDto, GetSampleWorkoutRoutine>(new GetSampleWorkoutRoutine {Id = command.Id}));
        }

        [Authorize(Policy = Policy.Admin)]
        [HttpPatch(ApiRoutes.SampleWorkoutRoutine.RestoreAsync)]
        public async Task<IActionResult> RestoreAsync([FromRoute] RestoreSampleWorkoutRoutine command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Ok(await QueryDispatcher.DispatchAsync<SampleWorkoutRoutineDetailsDto, GetSampleWorkoutRoutine>(new GetSampleWorkoutRoutine {Id = command.Id}));
        }
    }
}