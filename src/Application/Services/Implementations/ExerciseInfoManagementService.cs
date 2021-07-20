using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.ExerciseInfo;
using Application.Errors;
using Application.Exceptions;
using Application.Extensions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class ExerciseInfoManagementService : IExerciseInfoManagementService
    {
        private readonly IExerciseInfoRepository _exerciseInfoRepository;
        private readonly IMapper _mapper;
        public ExerciseInfoManagementService(IExerciseInfoRepository exerciseInfoRepository, IMapper mapper)
        {
            _exerciseInfoRepository = exerciseInfoRepository;
            _mapper = mapper;
        }
        public async Task<ExerciseInfoDetailsDto> GetAsync(Guid id)
            => _mapper.Map<ExerciseInfoDetailsDto>(await _exerciseInfoRepository.GetOrFailureAsync(id));
        public async Task<IEnumerable<ExerciseInfoDto>> BrowseWithoutArchiveAsync(int page, int perPage)
        {
            return _mapper.Map<IEnumerable<ExerciseInfoDto>>(await _exerciseInfoRepository.BrowseWithoutArchiveAsync(page, perPage));
        }
        public async Task<IEnumerable<ExerciseInfoDto>> BrowseArchiveAsync(int page, int perPage)
        {
            return _mapper.Map<IEnumerable<ExerciseInfoDto>>(await _exerciseInfoRepository.BrowseArchiveAsync(page, perPage));
        }
        public async Task CreateAsync(Guid id, string name, string description)
        {
            var exerciseInfo = await _exerciseInfoRepository.GetByNameAsync(name);
            if(exerciseInfo != null) throw new EntityAlreadyExistsException
            (
                ServiceErrorCodes.ExerciseInfo.AlreadyExists,
                $"Exercise info with name: {name} already exists."
            );

            try
            {
                exerciseInfo = new ExerciseInfo(id, name, description);
            }
            catch(InvalidIdException e)
            {
                throw new InternalException(e.Code, e.Message, e);
            }
            catch(InvalidNameException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            
            await _exerciseInfoRepository.AddAsync(exerciseInfo);
        }
        public async Task UpdateAsync(Guid id, string name, string description)
        {
            var exerciseInfo = await _exerciseInfoRepository.GetOrFailureAsync(id);

            try
            {
                exerciseInfo.SetName(name);
                exerciseInfo.SetDescription(description);
            }
            catch(InvalidNameException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }

            await _exerciseInfoRepository.UpdateAsync(exerciseInfo);
        }
        public async Task ArchiveAsync(Guid id)
        {
            var exerciseInfo = await _exerciseInfoRepository.GetOrFailureAsync(id);
            exerciseInfo.Archive();
            await _exerciseInfoRepository.UpdateAsync(exerciseInfo);
        }

        public async Task RestoreAsync(Guid id)
        {
            var exerciseInfo = await _exerciseInfoRepository.GetOrFailureAsync(id);
            exerciseInfo.Restore();
            await _exerciseInfoRepository.UpdateAsync(exerciseInfo);
        }
    }
}