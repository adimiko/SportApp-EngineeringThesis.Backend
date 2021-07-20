using System;
using System.Threading.Tasks;
using Application.DTOs.WorkoutStatistics;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Extensions;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class WorkoutsStatsService : IWorkoutsStatsService
    {
        private readonly IWorkoutsStatsRepository _workoutsStatsRepository;
        private readonly IMapper _mapper;

        public WorkoutsStatsService(IWorkoutsStatsRepository workoutsStatsRepository, IMapper mapper)
        {
            _workoutsStatsRepository = workoutsStatsRepository;
            _mapper = mapper;
        }
        public async Task<GlobalWorkoutsStatsDto> GetGlobalWorkoutsStatsAsync(Guid accountId)
            => _mapper.Map<GlobalWorkoutsStatsDto>(await _workoutsStatsRepository.GetGlobalWorkoutsStatsAsync(accountId));

        public async Task<WorkoutsStatsOverTimeDto> GetWorkoutsStatsCurrentWeekAsync(Guid accountId)
            => _mapper.Map<WorkoutsStatsOverTimeDto>(await _workoutsStatsRepository.GetWorkoutsStatsOverTimeAsync(accountId, DateTimeExtensions.GetTheWeekStartDate() ,DateTime.UtcNow.Date));
            
        public async Task<WorkoutsStatsOverTimeDto> GetWorkoutsStatsCurrentMonthAsync(Guid accountId)
            => _mapper.Map<WorkoutsStatsOverTimeDto>(await _workoutsStatsRepository.GetWorkoutsStatsOverTimeAsync(accountId, DateTimeExtensions.GetTheMonthStartDate() ,DateTime.UtcNow.Date));

        public async Task<WorkoutsStatsOverTimeDto> GetWorkoutsStatsCurrentYearAsync(Guid accountId)
            => _mapper.Map<WorkoutsStatsOverTimeDto>(await _workoutsStatsRepository.GetWorkoutsStatsOverTimeAsync(accountId, DateTimeExtensions.GetTheYearStartDate() ,DateTime.UtcNow.Date));

        public async Task<WorkoutsStatsOverTimeDto> GetWorkoutsStatsOverTimeAsync(Guid accountId, DateTime dateFrom, DateTime dateTo)
            => _mapper.Map<WorkoutsStatsOverTimeDto>(await _workoutsStatsRepository.GetWorkoutsStatsOverTimeAsync(accountId, dateFrom, dateTo));
    }
}