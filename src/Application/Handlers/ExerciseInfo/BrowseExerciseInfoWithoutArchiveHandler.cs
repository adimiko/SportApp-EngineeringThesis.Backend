using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.ExerciseInfo;
using Application.Queries;
using Application.Queries.ExerciseInfo;
using Application.Services.Interfaces;

namespace Application.Handlers.ExerciseInfo
{
    public class BrowseExerciseInfoWithoutArchiveHandler : IQueryHandler<BrowseExerciseInfoWithoutArchive, IEnumerable<ExerciseInfoDto>>
    {
        private readonly IExerciseInfoManagementService _exerciseInfoManagementService;
        public BrowseExerciseInfoWithoutArchiveHandler(IExerciseInfoManagementService exerciseInfoManagementService)
            => _exerciseInfoManagementService = exerciseInfoManagementService;
        public async Task<IEnumerable<ExerciseInfoDto>> HandleAsync(BrowseExerciseInfoWithoutArchive query)
            => await _exerciseInfoManagementService.BrowseWithoutArchiveAsync(query.Page, query.PerPage);
    }
}