using System;

namespace Application.DTOs.BodyMeasurements
{
    public class BodyMeasurementDto
    {
        public Guid Id {get; set;}
        public DateTime Date {get; set;}
        public string Description {get; set;}
    }
}