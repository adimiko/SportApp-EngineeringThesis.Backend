
using Application.DTOs.CompletedWorkout;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper.Configurations
{
    public static class CompletedWorkoutConfiguration
    {
        public static void CreateMapForCompletedWorkout(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CompletedWorkout, CompletedWorkoutDetailsDto>();
            cfg.CreateMap<CompletedWorkout, CompletedWorkoutDto>();
            cfg.CreateMap<CompletedExercise, CompletedExerciseDetailsDto>();
            cfg.CreateMap<CompletedSet, CompletedSetDetailsDto>();
        }
    }
}