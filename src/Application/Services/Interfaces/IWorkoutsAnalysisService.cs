using System;
using System.Threading.Tasks;
using Application.DTOs.WorkoutsAnalysis;

namespace Application.Services.Interfaces
{
    public interface IWorkoutsAnalysisService : IService
    {
        Task<WorkoutsAnalysisDto> GetWorkoutsAnalysisFromTheLastMonth(Guid userId);
    }
}