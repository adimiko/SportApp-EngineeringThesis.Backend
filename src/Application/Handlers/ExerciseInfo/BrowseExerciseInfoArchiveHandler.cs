using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.ExerciseInfo;
using Application.Queries;
using Application.Queries.ExerciseInfo;
using Application.Services.Interfaces;

namespace Application.Handlers.ExerciseInfo
{
    public class BrowseExerciseInfoArchiveHandler : IQueryHandler<BrowseExerciseInfoArchive, IEnumerable<ExerciseInfoDto>>
    {
        private readonly IExerciseInfoManagementService _exerciseInfoManagementService;
        public BrowseExerciseInfoArchiveHandler(IExerciseInfoManagementService exerciseInfoManagementService)
            => _exerciseInfoManagementService = exerciseInfoManagementService;
        public async Task<IEnumerable<ExerciseInfoDto>> HandleAsync(BrowseExerciseInfoArchive query)
            => await _exerciseInfoManagementService.BrowseArchiveAsync(query.Page, query.PerPage);
    }
}