using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.BodyMeasurement;
using Application.Services.Interfaces;

namespace Application.Handlers.BodyMeasurement
{
    public class CreateBodyMeasurementHandler : ICommandHandler<CreateBodyMeasurement>
    {
        private readonly IBodyMeasurementManagementService _bodyMeasurementManagementService;
        public CreateBodyMeasurementHandler(IBodyMeasurementManagementService bodyMeasurementManagementService)
            => _bodyMeasurementManagementService = bodyMeasurementManagementService;

        public async Task HandleAsync(CreateBodyMeasurement command)
            => await _bodyMeasurementManagementService.CreateAsync
            (
                command.Id,
                command.AccountId,
                command.Description,
                command.Date,
                command.Weight,
                command.Height,
                command.Arm,
                command.Chest,
                command.Waist,
                command.Hip,
                command.Thigh,
                command.Calf
            );
    }
}