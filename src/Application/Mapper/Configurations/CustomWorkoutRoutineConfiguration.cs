using Application.DTOs.CustomWorkoutRoutine;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper.Configurations
{
    public static class CustomWorkoutRoutineConfiguration
    {
        public static void CreateMapForCustomWorkoutRoutine(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CustomWorkoutRoutine, CustomWorkoutRoutineDto>();
            cfg.CreateMap<CustomWorkoutRoutine, CustomWorkoutRoutineDetailsDto>();
        }
    }
}