using System.Threading.Tasks;
using Application.DTOs.BodyMeasurements;
using Application.Queries;
using Application.Queries.BodyMeasurement;
using Application.Services.Interfaces;

namespace Application.Handlers.BodyMeasurement
{
    public class GetBodyMeasurementHandler : IQueryHandler<GetBodyMeasurement, BodyMeasurementDetailsDto>
    {
        private readonly IBodyMeasurementManagementService _bodyMeasurementManagementService;
        public GetBodyMeasurementHandler(IBodyMeasurementManagementService bodyMeasurementManagementService)
            => _bodyMeasurementManagementService = bodyMeasurementManagementService;
        public async Task<BodyMeasurementDetailsDto> HandleAsync(GetBodyMeasurement query)
            => await _bodyMeasurementManagementService.GetAsync(query.Id, query.AccountId);
    }
}