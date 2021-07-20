using Application.DTOs.SampleWorkoutRoutine;
using Application.DTOs.WorkoutRoutine;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper.Configurations
{
    public static class SampleWorkoutRoutineConfiguration
    {
        public static void CreateMapForSampleWorkoutRoutine(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<SampleWorkoutRoutine, SampleWorkoutRoutineDto>();
            cfg.CreateMap<SampleWorkoutRoutine, SampleWorkoutRoutineDetailsDto>();
        }
    }
}