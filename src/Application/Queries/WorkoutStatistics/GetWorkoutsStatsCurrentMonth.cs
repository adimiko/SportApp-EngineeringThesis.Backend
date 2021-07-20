using System;
using Application.DTOs.WorkoutStatistics;

namespace Application.Queries.WorkoutStatistics
{
    public class GetWorkoutsStatsCurrentMonth : IQuery<WorkoutsStatsOverTimeDto>
    {
        public Guid AccountId {get; set;}
    }
}