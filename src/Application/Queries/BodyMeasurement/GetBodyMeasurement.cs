using System;
using Application.DTOs.BodyMeasurements;

namespace Application.Queries.BodyMeasurement
{
    public class GetBodyMeasurement : IQuery<BodyMeasurementDetailsDto>
    {
        public Guid Id {get; set;}
        public Guid AccountId {get; set;}
    }
}