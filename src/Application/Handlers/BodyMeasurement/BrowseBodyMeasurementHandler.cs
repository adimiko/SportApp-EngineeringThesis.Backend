using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.BodyMeasurements;
using Application.Queries;
using Application.Queries.BodyMeasurement;
using Application.Services.Interfaces;

namespace Application.Handlers.BodyMeasurement
{
    public class BrowseBodyMeasurementHandler : IQueryHandler<BrowseBodyMeasurement, IEnumerable<BodyMeasurementDto>>
    {
        private readonly IBodyMeasurementManagementService _bodyMeasurementManagementService;
        public BrowseBodyMeasurementHandler(IBodyMeasurementManagementService bodyMeasurementManagementService)
            => _bodyMeasurementManagementService = bodyMeasurementManagementService;
        public async Task<IEnumerable<BodyMeasurementDto>> HandleAsync(BrowseBodyMeasurement query)
            => await _bodyMeasurementManagementService.BrowseAsync
            (
                query.AccountId,
                query.Page,
                query.PerPage
            );
    }
}