using System;
using System.Collections.Generic;
using Application.DTOs.BodyMeasurements;

namespace Application.Queries.BodyMeasurement
{
    public class BrowseBodyMeasurement : IQuery<IEnumerable<BodyMeasurementDto>>
    {
        public Guid AccountId {get; set;}
        public int Page {get; set;} = 1;
        public int PerPage {get; set;} = 10000;
    }
}