using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.CompletedWorkout;
using Application.Queries;
using Application.Queries.CompletedWorkout;
using Application.Services.Interfaces;

namespace Application.Handlers.CompletedWorkout
{
    public class BrowseCompletedWorkoutHandler : IQueryHandler<BrowseCompletedWorkout, IEnumerable<CompletedWorkoutDto>>
    {
        private readonly ICompletedWorkoutManagementService _completedWorkoutManagementService;
        public BrowseCompletedWorkoutHandler(ICompletedWorkoutManagementService completedWorkoutManagementService)
            => _completedWorkoutManagementService = completedWorkoutManagementService;
        public async Task<IEnumerable<CompletedWorkoutDto>> HandleAsync(BrowseCompletedWorkout query)
            => await _completedWorkoutManagementService.BrowseAsync
            (
                query.AccountId,
                query.Page,
                query.PerPage
            );
    }
}