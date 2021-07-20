using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CompletedWorkout;
using Application.DTOs.CompletedWorkout;
using Application.Exceptions;
using Application.Extensions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class CompletedWorkoutManagementService : ICompletedWorkoutManagementService
    {
        private readonly ICompletedWorkoutRepository _completedWorkoutRepository;
        private readonly IExerciseInfoRepository _exerciseInfoRepository;
        private readonly IMapper _mapper;

        public CompletedWorkoutManagementService(ICompletedWorkoutRepository completedWorkoutRepository, IExerciseInfoRepository exerciseInfoRepository, IMapper mapper)
        {
            _completedWorkoutRepository = completedWorkoutRepository;
            _exerciseInfoRepository = exerciseInfoRepository;
            _mapper = mapper;
        }

        public async Task<CompletedWorkoutDetailsDto> GetAsync(Guid id, Guid accountId)
        {
            var completedWorkout = await _completedWorkoutRepository.GetOrFailureAsync(id);
            if(completedWorkout.AccountId != accountId) throw new AccessDeniedException("You do not have access to this resource");

            var completedWorkoutDetailsDto = _mapper.Map<CompletedWorkoutDetailsDto>(completedWorkout);

            foreach(var exercise in completedWorkoutDetailsDto.Exercises)
            {
                var exerciseInfo = await _exerciseInfoRepository.GetAsync(exercise.ExerciseInfoId);
                exercise.Name = exerciseInfo.Name;
            }

            return completedWorkoutDetailsDto;
        }

        public async Task<IEnumerable<CompletedWorkoutDto>> BrowseAsync(Guid accountId, int page, int perPage)
            => _mapper.Map<IEnumerable<CompletedWorkoutDto>>(await _completedWorkoutRepository.BrowseAsync(accountId, page, perPage));

        public async Task CreateAsync(Guid id, Guid accountId, string name, string workoutNote, int duration, DateTime date, IEnumerable<CreateCompletedExercise> exercises)
        {
            try
            {
                var completedWorkout = new CompletedWorkout(id, accountId, name, workoutNote, duration, date);
                foreach(var exercise in exercises)
                {
                    var exerciseInfo = await _exerciseInfoRepository.GetOrFailureAsync(exercise.ExerciseInfoId);

                    completedWorkout.AddExercise(exerciseInfo);

                    foreach(var set in exercise.Sets)
                        completedWorkout.Exercises.LastOrDefault().AddSet(set.Reps, set.Weight);
                }

                await _completedWorkoutRepository.AddAsync(completedWorkout);
            }
            catch(InvalidNameException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidOrderException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidDurationException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidRepsException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidWeightException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidIdException e)
            {
                throw new InternalException(e.Code, e.Message, e);
            }
        }

        public async Task DeleteAsync(Guid id, Guid accountId)
        {
            var completedWorkout = await _completedWorkoutRepository.GetOrFailureAsync(id);
            if(completedWorkout.AccountId != accountId) throw new AccessDeniedException("You do not have access to this resource");
            await _completedWorkoutRepository.DeleteAsync(completedWorkout);
        }
    }
}