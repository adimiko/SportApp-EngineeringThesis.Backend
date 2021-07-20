using Application.DTOs.WorkoutRoutine;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper.Configurations
{
    public static class WorkoutRoutineConfiguration
    {
        public static void CreateMapForWorkoutRoutine(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Exercise, ExerciseDetailsDto>();
        }
    }
}