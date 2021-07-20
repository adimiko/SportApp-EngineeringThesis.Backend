using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.BodyMeasurement;
using Application.Services.Interfaces;

namespace Application.Handlers.BodyMeasurement
{
    public class DeleteBodyMeasurementHandler : ICommandHandler<DeleteBodyMeasurement>
    {
        private readonly IBodyMeasurementManagementService _bodyMeasurementManagementService;
        public DeleteBodyMeasurementHandler(IBodyMeasurementManagementService bodyMeasurementManagementService)
            => _bodyMeasurementManagementService = bodyMeasurementManagementService;
        public async Task HandleAsync(DeleteBodyMeasurement command)
            => await _bodyMeasurementManagementService.DeleteAsync
            (
                command.Id,
                command.AccountId
            );
    }
}