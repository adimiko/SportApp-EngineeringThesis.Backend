using System.Threading.Tasks;
using Api.Contracts.V1;
using Api.Policies;
using Application.Commands;
using Application.DTOs.WorkoutsAnalysis;
using Application.Queries;
using Application.Queries.WorkoutsAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Policy = Policy.User)]
    public class WorkoutsAnalysisController : ApiControllerBase
    {
        public WorkoutsAnalysisController(ICommandDispatcher commandDispatcher,  IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher){ }

        [HttpGet(ApiRoutes.WorkoutsAnalysis.GetWorkoutsAnalysisFromTheLastMonthAsync)]
        public async Task<IActionResult> GetWorkoutsAnalysisFromTheLastMonthAsync()
        {
            var query = new GetWorkoutsAnalysisFromTheLastMonth();
            query.AccountId = AccountId;
            return Json(await QueryDispatcher.DispatchAsync<WorkoutsAnalysisDto, GetWorkoutsAnalysisFromTheLastMonth>(query));
        }
    }
}