using System;
using Application.DTOs.WorkoutStatistics;

namespace Application.Queries.WorkoutStatistics
{
    public class GetWorkoutsStatsCurrentWeek : IQuery<WorkoutsStatsOverTimeDto>
    {
        public Guid AccountId {get; set;}
    }
}