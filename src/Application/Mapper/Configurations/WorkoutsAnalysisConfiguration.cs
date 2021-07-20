using Application.DTOs.WorkoutsAnalysis;
using AutoMapper;
using Domain.ValueObjects;

namespace Application.Mapper.Configurations
{
    public static class WorkoutsAnalysisConfiguration
    {
        public static void CreateMapForWorkoutsAnalysis(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<WorkoutsAnalysis, WorkoutsAnalysisDto>();
        }
    }
}