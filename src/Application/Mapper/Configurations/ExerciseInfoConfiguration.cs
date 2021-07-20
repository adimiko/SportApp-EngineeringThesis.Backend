using Application.DTOs.ExerciseInfo;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper.Configurations
{
    public static class ExerciseInfoConfiguration
    {
        public static void CreateMapForExerciseInfo(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ExerciseInfo, ExerciseInfoDetailsDto>();
            cfg.CreateMap<ExerciseInfo, ExerciseInfoDto>();
        }
    }
}