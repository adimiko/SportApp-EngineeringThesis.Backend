using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.WorkoutRoutine;
using Application.DTOs.SampleWorkoutRoutine;
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
    public class SampleWorkoutRoutineManagementService : ISampleWorkoutRoutineManagementService
    {
        private readonly ISampleWorkoutRoutineRepository _sampleWorkoutRoutineRepository;
        private readonly IExerciseInfoRepository _exerciseInfoRepository;
        private readonly IMapper _mapper;

        public SampleWorkoutRoutineManagementService(ISampleWorkoutRoutineRepository sampleWorkoutRoutineRepository, IExerciseInfoRepository exerciseInfoRepository, IMapper mapper)
        {
            _sampleWorkoutRoutineRepository = sampleWorkoutRoutineRepository;
            _exerciseInfoRepository = exerciseInfoRepository;
            _mapper = mapper;
        }

        public async Task<SampleWorkoutRoutineDetailsDto> GetAsync(Guid id)
        {
            var sampleWorkoutRoutineDetailsDto = _mapper.Map<SampleWorkoutRoutineDetailsDto>(await _sampleWorkoutRoutineRepository.GetOrFailureAsync(id));
            foreach(var exercise in sampleWorkoutRoutineDetailsDto.Exercises)
            {
                var exerciseInfo = await _exerciseInfoRepository.GetAsync(exercise.ExerciseInfoId);
                exercise.Name = exerciseInfo.Name;
            }
            return sampleWorkoutRoutineDetailsDto;
        }


        public async Task<IEnumerable<SampleWorkoutRoutineDto>> BrowseWithoutArchiveAsync(int page, int perPage)
            => _mapper.Map<IEnumerable<SampleWorkoutRoutineDto>>(await _sampleWorkoutRoutineRepository.BrowseWithoutArchiveAsync(page, perPage));

        public async Task<IEnumerable<SampleWorkoutRoutineDto>> BrowseArchiveAsync(int page, int perPage)
            => _mapper.Map<IEnumerable<SampleWorkoutRoutineDto>>(await _sampleWorkoutRoutineRepository.BrowseArchiveAsync(page, perPage));
        public async Task CreateAsync(Guid id, string name, IEnumerable<CreateExercise> exercises)
        {
            var sampleWorkoutRoutine = await _sampleWorkoutRoutineRepository.GetByNameAsync(name);

            if(sampleWorkoutRoutine != null) throw new EntityAlreadyExistsException
            (
                ServiceErrorCodes.SampleWorkoutRoutine.AlreadyExists,
                $"Sample workout routine with name: {name} already exists."
            );

            try
            {
                ISet<Exercise> domainExercises = new HashSet<Exercise>();
                foreach(var exercise in exercises)
                {
                    var exerciseInfo = await _exerciseInfoRepository.GetOrFailureAsync(exercise.ExerciseInfoId);

                    domainExercises.Add(new Exercise(Guid.NewGuid(), Guid.NewGuid(), exercise.ExerciseInfoId, exercise.Order, exercise.NumberOfSets));
                }

                sampleWorkoutRoutine = new SampleWorkoutRoutine(id, name, domainExercises);

                await _sampleWorkoutRoutineRepository.AddAsync(sampleWorkoutRoutine);
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
            var sampleWorkoutRoutine = await _sampleWorkoutRoutineRepository.GetOrFailureAsync(id);

            
            ISet<Exercise> domainExercises = new HashSet<Exercise>();
            foreach(var exercise in exercises)
            {
                var exerciseInfo = await _exerciseInfoRepository.GetOrFailureAsync(exercise.ExerciseInfoId);
                domainExercises.Add(new Exercise(exercise.Id, Guid.NewGuid(), exercise.ExerciseInfoId, exercise.Order, exercise.NumberOfSets));
            }

            sampleWorkoutRoutine.SetName(name);
            sampleWorkoutRoutine.SetExercises(domainExercises);

            await _sampleWorkoutRoutineRepository.UpdateAsync(sampleWorkoutRoutine);
        }

        public async Task ArchiveAsync(Guid id)
        {
            var sampleWorkoutRoutine = await _sampleWorkoutRoutineRepository.GetOrFailureAsync(id);
            sampleWorkoutRoutine .Archive();
            await _sampleWorkoutRoutineRepository.UpdateAsync(sampleWorkoutRoutine);
        }

        public async Task RestoreAsync(Guid id)
        {
            var sampleWorkoutRoutine = await _sampleWorkoutRoutineRepository.GetOrFailureAsync(id);
            sampleWorkoutRoutine.Restore();
            await _sampleWorkoutRoutineRepository.UpdateAsync(sampleWorkoutRoutine);
        }


    }
}