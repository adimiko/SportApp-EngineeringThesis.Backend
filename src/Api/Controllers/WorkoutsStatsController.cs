using System.Threading.Tasks;
using Api.Contracts.V1;
using Api.Policies;
using Application.Commands;
using Application.DTOs.WorkoutStatistics;
using Application.Queries;
using Application.Queries.WorkoutStatistics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Policy = Policy.User)]
    public class WorkoutsStatsController : ApiControllerBase
    {
        public WorkoutsStatsController(ICommandDispatcher commandDispatcher,  IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher){ }

        [HttpGet(ApiRoutes.WorkoutsStats.GetGlobalWorkoutsStatsAsync)]
        public async Task<IActionResult> GetGlobalWorkoutsStatsAsync()
        {
            var query = new GetGlobalWorkoutsStats();
            query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<GlobalWorkoutsStatsDto, GetGlobalWorkoutsStats>(query));
        }

        [HttpGet(ApiRoutes.WorkoutsStats.GetWorkoutsStatsCurrentWeekAsync)]
        public async Task<IActionResult> GetWorkoutsStatsCurrentWeekAsync(GetWorkoutsStatsCurrentWeek query)
        {
            query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<WorkoutsStatsOverTimeDto, GetWorkoutsStatsCurrentWeek>(query));
        }

        [HttpGet(ApiRoutes.WorkoutsStats.GetWorkoutsStatsCurrentMonthAsync)]
        public async Task<IActionResult> GetWorkoutsStatsCurrentMonthAsync(GetWorkoutsStatsCurrentMonth query)
        {
            query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<WorkoutsStatsOverTimeDto, GetWorkoutsStatsCurrentMonth>(query));
        }  

        [HttpGet(ApiRoutes.WorkoutsStats.GetWorkoutsStatsCurrentYearAsync)]
        public async Task<IActionResult> GetWorkoutsStatsCurrentYearAsync(GetWorkoutsStatsCurrentYear query)
        {
            query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<WorkoutsStatsOverTimeDto, GetWorkoutsStatsCurrentYear>(query));
        }  
    }
}