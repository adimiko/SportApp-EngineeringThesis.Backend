using System;
using Application.DTOs.WorkoutsAnalysis;

namespace Application.Queries.WorkoutsAnalysis
{
    public class GetWorkoutsAnalysisFromTheLastMonth : IQuery<WorkoutsAnalysisDto>
    {
        public Guid AccountId {get; set;}
    }
}