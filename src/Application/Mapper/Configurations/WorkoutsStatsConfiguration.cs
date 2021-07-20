using Application.DTOs.WorkoutStatistics;
using AutoMapper;
using Domain.ValueObjects;

namespace Application.Mapper.Configurations
{
    public static class WorkoutsStatsConfiguration
    {
        public static void CreateMapForWorkoutsStats(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<GlobalWorkoutsStats, GlobalWorkoutsStatsDto>();
            cfg.CreateMap<WorkoutsStatsOverTime, WorkoutsStatsOverTimeDto>();
        }
    }
}