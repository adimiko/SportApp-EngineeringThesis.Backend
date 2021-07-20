using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.WorkoutRoutine;
using Application.DTOs.CustomWorkoutRoutine;
using Application.DTOs.WorkoutRoutine;
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
    public class CustomWorkoutRoutineManagementService : ICustomWorkoutRoutineManagementService
    {
        private readonly ICustomWorkoutRoutineRepository _customWorkoutRoutineRepository;
        private readonly IExerciseInfoRepository _exerciseInfoRepository;
        private readonly IMapper _mapper;

        public CustomWorkoutRoutineManagementService(ICustomWorkoutRoutineRepository customWorkoutRoutineRepository, IExerciseInfoRepository exerciseInfoRepository, IMapper mapper)
        {
            _customWorkoutRoutineRepository = customWorkoutRoutineRepository;
            _exerciseInfoRepository = exerciseInfoRepository;
            _mapper = mapper;
        }

        public async Task<CustomWorkoutRoutineDetailsDto> GetAsync(Guid id, Guid accountId)
        {
            var customWorkoutRoutine = await _customWorkoutRoutineRepository.GetOrFailureAsync(id);
            if(customWorkoutRoutine.AccountId != accountId) throw new AccessDeniedException("You do not have access to this resource");
            var customWorkoutRoutineDetailsDto = _mapper.Map<CustomWorkoutRoutineDetailsDto>(customWorkoutRoutine);

            foreach(var exercise in customWorkoutRoutineDetailsDto.Exercises)
            {
                var exerciseInfo = await _exerciseInfoRepository.GetAsync(exercise.ExerciseInfoId);
                exercise.Name = exerciseInfo.Name;
            }

            return customWorkoutRoutineDetailsDto;
        }

        public async Task<IEnumerable<CustomWorkoutRoutineDto>> BrowseWithoutArchiveAsync(Guid accountId, int page, int perPage)
            => _mapper.Map<IEnumerable<CustomWorkoutRoutineDto>>(await _customWorkoutRoutineRepository.BrowseWithoutArchiveAsync(accountId, page, perPage));

        public async Task<IEnumerable<CustomWorkoutRoutineDto>> BrowseArchiveAsync(Guid accountId, int page, int perPage)
            => _mapper.Map<IEnumerable<CustomWorkoutRoutineDto>>(await _customWorkoutRoutineRepository.BrowseArchiveAsync(accountId, page, perPage));

        public async Task CreateAsync(Guid id, Guid accountId, string name, IEnumerable<CreateExercise> exercises)
        {
            try
            {
                ISet<Exercise> domainExercises = new HashSet<Exercise>();

                
                foreach(var exercise in exercises)
                {
                    var exerciseInfo = await _exerciseInfoRepository.GetOrFailureAsync(exercise.ExerciseInfoId);
                    domainExercises.Add(new Exercise(Guid.NewGuid(), Guid.NewGuid(), exercise.ExerciseInfoId, exercise.Order, exercise.NumberOfSets));
                }
                var customWorkoutRoutine = new CustomWorkoutRoutine(id, accountId, name, domainExercises);
                await _customWorkoutRoutineRepository.AddAsync(customWorkoutRoutine);
            }
            catch(InvalidNameException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidOrderException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidNumberOfSetsException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidIdException e)
            {
                throw new InternalException(e.Code, e.Message, e);
            }
        }


        public async Task UpdateAsync(Guid id, string name, IEnumerable<UpdateExercise> exercises)
        {
            var customWorkoutRoutine = await _customWorkoutRoutineRepository.GetOrFailureAsync(id);

            customWorkoutRoutine.SetName(name);

            ISet<Exercise> domainExercises = new HashSet<Exercise>();
            foreach(var exercise in exercises)
            {
                var exerciseInfo = await _exerciseInfoRepository.GetOrFailureAsync(exercise.ExerciseInfoId);
                domainExercises.Add(new Exercise(Guid.NewGuid(), Guid.NewGuid(), exercise.ExerciseInfoId, exercise.Order, exercise.NumberOfSets));
            }

            customWorkoutRoutine.SetExercises(domainExercises);
            await _customWorkoutRoutineRepository.UpdateAsync(customWorkoutRoutine);
        }
        
        public async Task ArchiveAsync(Guid id, Guid accountId)
        {
            var customWorkoutRoutine = await _customWorkoutRoutineRepository.GetOrFailureAsync(id);

            if(customWorkoutRoutine.AccountId != accountId) throw new AccessDeniedException("You do not have access to this resource");
            customWorkoutRoutine.Archive();
            await _customWorkoutRoutineRepository.UpdateAsync(customWorkoutRoutine);
        }

        public async Task RestoreAsync(Guid id, Guid accountId)
        {
            var customWorkoutRoutine = await _customWorkoutRoutineRepository.GetOrFailureAsync(id);

            if(customWorkoutRoutine.AccountId != accountId) throw new AccessDeniedException("You do not have access to this resource");
            customWorkoutRoutine.Restore();
            await _customWorkoutRoutineRepository.UpdateAsync(customWorkoutRoutine);
        }


    }
}