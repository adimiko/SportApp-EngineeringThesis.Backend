using System.Threading.Tasks;
using Application.DTOs.WorkoutsAnalysis;
using Application.Queries;
using Application.Queries.WorkoutsAnalysis;
using Application.Services.Interfaces;

namespace Application.Handlers.WorkoutsAnalysis
{
    public class GetWorkoutsAnalysisFromTheLastMonthHandler : IQueryHandler<GetWorkoutsAnalysisFromTheLastMonth, WorkoutsAnalysisDto>
    {
        private readonly IWorkoutsAnalysisService _workoutsAnalysisService;

        public GetWorkoutsAnalysisFromTheLastMonthHandler(IWorkoutsAnalysisService workoutsAnalysisService)
            => _workoutsAnalysisService = workoutsAnalysisService;
        public async Task<WorkoutsAnalysisDto> HandleAsync(GetWorkoutsAnalysisFromTheLastMonth query)
            => await _workoutsAnalysisService.GetWorkoutsAnalysisFromTheLastMonth(query.AccountId);
    }
}