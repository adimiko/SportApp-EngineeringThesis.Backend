using System;
using System.Threading.Tasks;
using Application.DTOs.WorkoutsAnalysis;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Services.Implementations
{

    public class WorkoutsAnalysisService : IWorkoutsAnalysisService
    {
        private readonly IWorkoutsStatsRepository _workoutsStatsRepository;
        private readonly IMapper _mapper;
        public WorkoutsAnalysisService(IWorkoutsStatsRepository workoutsStatsRepository, IMapper mapper)
        {
            _workoutsStatsRepository = workoutsStatsRepository;
            _mapper = mapper;
        }
        public async Task<WorkoutsAnalysisDto> GetWorkoutsAnalysisFromTheLastMonth(Guid userId)
        {
            var currentMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var lastMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.AddMonths(-1).Month, 1);
            var monthBeforeLastMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.AddMonths(-2).Month, 1);



            var firstMonth = await _workoutsStatsRepository.GetWorkoutsStatsOverTimeAsync(userId, monthBeforeLastMonth, lastMonth);
            var secoundMonth = await _workoutsStatsRepository.GetWorkoutsStatsOverTimeAsync(userId, lastMonth, currentMonth);
            
            WorkoutsAnalysis workoutsAnalysis;
            try
            {
                workoutsAnalysis = new WorkoutsAnalysis(firstMonth, secoundMonth);
            }
            catch(NotEnoughDataException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }

            return _mapper.Map<WorkoutsAnalysisDto>(workoutsAnalysis);
        }
    }
}