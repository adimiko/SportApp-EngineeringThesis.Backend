using System;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.BodyMeasurement;
using Application.Services.Interfaces;

namespace Application.Handlers.BodyMeasurement
{
    public class UpdateBodyMeasurementHandler : ICommandHandler<UpdateBodyMeasurement>
    {
        private readonly IBodyMeasurementManagementService _bodyMeasurementManagementService;
        public UpdateBodyMeasurementHandler(IBodyMeasurementManagementService bodyMeasurementManagementService)
            => _bodyMeasurementManagementService = bodyMeasurementManagementService;

        public async Task HandleAsync(UpdateBodyMeasurement command)
            => await _bodyMeasurementManagementService.UpdateAsync
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