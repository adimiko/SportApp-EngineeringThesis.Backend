using System;
using System.Threading.Tasks;
using Application.Errors;
using Application.Exceptions;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<ExerciseInfo> GetOrFailureAsync(this IExerciseInfoRepository repository, Guid id)
        {
            var entity = await repository.GetAsync(id);
            if(entity == null) throw new EntityDoesNotExistException(ServiceErrorCodes.ExerciseInfo.NotFound ,$"Exercise info with id {id} does not exist.");
            return entity;
        }

        public static async Task<BodyMeasurement> GetOrFailureAsync(this IBodyMeasurementRepository repository, Guid id)
        {
            var entity = await repository.GetAsync(id);
            if(entity == null) throw new EntityDoesNotExistException(ServiceErrorCodes.BodyMeasurement.NotFound ,$"Body measurement with id {id} does not exist.");
            return entity;
        }

        public static async Task<SampleWorkoutRoutine> GetOrFailureAsync(this ISampleWorkoutRoutineRepository repository, Guid id)
        {
            var entity = await repository.GetAsync(id);
            if(entity == null) throw new EntityDoesNotExistException(ServiceErrorCodes.SampleWorkoutRoutine.NotFound ,$"Sample workout routine with id {id} does not exist.");
            return entity;
        }

        public static async Task<CustomWorkoutRoutine> GetOrFailureAsync(this ICustomWorkoutRoutineRepository repository, Guid id)
        {
            var entity = await repository.GetAsync(id);
            if(entity == null) throw new EntityDoesNotExistException(ServiceErrorCodes.CustomWorkoutRoutine.NotFound ,$"Custom workout routine with id {id} does not exist.");
            return entity;
        }

        public static async Task<SampleWorkoutRoutine> GetByNameOrFailureAsync(this ISampleWorkoutRoutineRepository repository, string name)
        {
            var entity = await repository.GetByNameAsync(name);
            if(entity == null) throw new EntityDoesNotExistException(ServiceErrorCodes.SampleWorkoutRoutine.NotFound ,$"Sample workout routine with name {name} does not exist.");
            return entity;
        }

        public static async Task<CustomWorkoutRoutine> GetByNameOrFailureAsync(this ICustomWorkoutRoutineRepository repository, string name)
        {
            var entity = await repository.GetByNameAsync(name);
            if(entity == null) throw new EntityDoesNotExistException(ServiceErrorCodes.CustomWorkoutRoutine.NotFound ,$"Custom workout routine info with name {name} does not exist.");
            return entity;
        }

        public static async Task<CompletedWorkout> GetOrFailureAsync(this ICompletedWorkoutRepository repository, Guid id)
        {
            var entity = await repository.GetAsync(id);
            if(entity == null) throw new EntityDoesNotExistException(ServiceErrorCodes.CompletedWorkout.NotFound ,$"Custom workout routine info with id {id} does not exist.");
            return entity;
        }
    }
}