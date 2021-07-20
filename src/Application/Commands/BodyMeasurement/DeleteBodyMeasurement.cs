using System;

namespace Application.Commands.BodyMeasurement
{
    public class DeleteBodyMeasurement : ICommand
    {
        public Guid Id {get; set;}
        public Guid AccountId {get; set;}
    }
}