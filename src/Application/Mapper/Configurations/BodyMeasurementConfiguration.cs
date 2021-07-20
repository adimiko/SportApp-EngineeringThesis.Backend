using Application.DTOs.BodyMeasurements;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper.Configurations
{
    public static class BodyMeasurementConfiguration
    {
        public static void CreateMapForBodyMeasurement(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<BodyMeasurement, BodyMeasurementDetailsDto>();
            cfg.CreateMap<BodyMeasurement, BodyMeasurementDto>();
        }
    }
}