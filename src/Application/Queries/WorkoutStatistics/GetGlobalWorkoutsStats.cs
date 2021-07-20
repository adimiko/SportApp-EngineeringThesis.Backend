using System;
using Application.DTOs.WorkoutStatistics;

namespace Application.Queries.WorkoutStatistics
{
    public class GetGlobalWorkoutsStats : IQuery<GlobalWorkoutsStatsDto>
    {
        public Guid AccountId {get; set;}
    }
}