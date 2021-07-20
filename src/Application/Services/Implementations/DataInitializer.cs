using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CompletedWorkout;
using Application.Commands.WorkoutRoutine;
using Application.Services.Interfaces;

namespace Application.Services.Implementations
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IIdentityService _identityService;
        private readonly IExerciseInfoManagementService _exerciseInfoManagementService;
        private readonly IBodyMeasurementManagementService _bodyMeasurementManagementService;
        private readonly ISampleWorkoutRoutineManagementService _sampleWorkoutRoutineManagementService;
        private readonly ICustomWorkoutRoutineManagementService _customWorkoutRoutineManagementService;

        private readonly ICompletedWorkoutManagementService _completedWorkoutManagementService;

        public DataInitializer(IExerciseInfoManagementService exerciseInfoManagementService, IIdentityService identityService,
            IBodyMeasurementManagementService bodyMeasurementManagementService,
            ISampleWorkoutRoutineManagementService sampleWorkoutRoutineManagementService,
            ICustomWorkoutRoutineManagementService customWorkoutRoutineManagementService,
            ICompletedWorkoutManagementService completedWorkoutManagementService)
        {
            _identityService = identityService;
            _exerciseInfoManagementService = exerciseInfoManagementService;
            _bodyMeasurementManagementService = bodyMeasurementManagementService;
            _sampleWorkoutRoutineManagementService = sampleWorkoutRoutineManagementService;
            _customWorkoutRoutineManagementService = customWorkoutRoutineManagementService;
            _completedWorkoutManagementService = completedWorkoutManagementService;
        }
        public async Task SeedAsync()
        {
            await RegisterExampleAdmin();
            await AddExampleExerciseInfo();
            await AddExampleSampleWorkoutRoutines();


            var userId = Guid.NewGuid();
            await RegisterExampleUser(userId);
            await AddExampleBodyMeasurements(userId);
            await AddExampleCustomWorkoutRoutines(userId);
            await AddExampleCompletedWorkoutRoutines(userId);
        }

        private async Task RegisterExampleAdmin()
            => await _identityService.RegisterAsync(Guid.NewGuid(),"admin-account@mail.com","admin-account","admin123","admin123","admin");

        private async Task RegisterExampleUser(Guid userId)
            => await _identityService.RegisterAsync(userId, "user-account@mail.com", "user-account", "user1234", "user1234", "user");

        private async Task AddExampleExerciseInfo()
        {
            await _exerciseInfoManagementService.CreateAsync(Guid.NewGuid(), "Pull Up", "Description");
            await _exerciseInfoManagementService.CreateAsync(Guid.NewGuid(), "Chin Up", "Description");
            await _exerciseInfoManagementService.CreateAsync(Guid.NewGuid(), "Classic Squats", "Description");
            await _exerciseInfoManagementService.CreateAsync(Guid.NewGuid(), "Bench Press", "Description");
            await _exerciseInfoManagementService.CreateAsync(Guid.NewGuid(), "Overhead Press", "Description");
            await _exerciseInfoManagementService.CreateAsync(Guid.NewGuid(), "Deadlift", "Description");
            await _exerciseInfoManagementService.CreateAsync(Guid.NewGuid(), "Barbell Row", "Description");
        }

        private async Task AddExampleBodyMeasurements(Guid userId)
        {
            var tasks = new List<Task>();
            for(int i=0; i<10; i++)
                tasks.Add(_bodyMeasurementManagementService.CreateAsync(Guid.NewGuid(), userId, $"Body Measurement {i}", DateTime.UtcNow.AddDays(-i), 80 + i, 180 + i, 40 + i, 130 + i, 20 + i, 120 + i, 50 + i, 40 + i));

            await Task.WhenAll(tasks);  
        }

        private async Task AddExampleSampleWorkoutRoutines()
        {
            for(int i = 0; i < 10; i++)
                await AddExampleSampleWorkoutRoutine($"Sample Workout Routine {i}");
        }

        private async Task AddExampleSampleWorkoutRoutine(string sampleWorkoutRoutineName)
        {

            var exericseInfo = await _exerciseInfoManagementService.BrowseWithoutArchiveAsync(1,10);
            var ei = exericseInfo.ToArray();


                var newExercises = new HashSet<CreateExercise>();
                for(int i=0 ; i < exericseInfo.Count(); i++)
                {
                    var exercise = new CreateExercise()
                    {
                        ExerciseInfoId = ei[i].Id,
                        Order = i + 1,
                        NumberOfSets = 4
                    };
                    newExercises.Add(exercise);
                }

                await _sampleWorkoutRoutineManagementService.CreateAsync(Guid.NewGuid(), sampleWorkoutRoutineName, newExercises);
        }

        private async Task AddExampleCustomWorkoutRoutines(Guid userId)
        {
            for(int i = 0; i < 10; i++)
                await AddExampleCustomWorkoutRoutine(userId, $"My Workout Routine {i}");
        }
        private async Task AddExampleCustomWorkoutRoutine(Guid userId, string customWorkoutRoutineName)
        {

            var exericseInfo = await _exerciseInfoManagementService.BrowseWithoutArchiveAsync(1,10);
            var ei = exericseInfo.ToArray();


                var newExercises = new HashSet<CreateExercise>();
                for(int i=0 ; i < exericseInfo.Count(); i++)
                {
                    var exercise = new CreateExercise()
                    {
                        ExerciseInfoId = ei[i].Id,
                        Order = i + 1,
                        NumberOfSets = 4
                    };
                    newExercises.Add(exercise);
                }

                await _customWorkoutRoutineManagementService.CreateAsync(Guid.NewGuid(), userId,customWorkoutRoutineName , newExercises);
        }

        private async Task AddExampleCompletedWorkoutRoutines(Guid userId)
        {
            Random radom = new Random();
            for(int i = 0; i < 100; i++)
                await AddExampleCompletedWorkoutRoutine(userId, $"My Completed Workout {i}",DateTime.UtcNow.AddDays(-(i*radom.Next(1,5))));
            
        }
        private async Task AddExampleCompletedWorkoutRoutine(Guid userId, string workoutName, DateTime date)
        {
            Random radom = new Random();

            var exericseInfo = await _exerciseInfoManagementService.BrowseWithoutArchiveAsync(1,10);
            var ei = exericseInfo.ToArray();

                var newExercises = new HashSet<CreateCompletedExercise>();
                for(int i=0 ; i < exericseInfo.Count(); i++)
                {
                    var completedExercise = new CreateCompletedExercise()
                    {
                        ExerciseInfoId = ei[i].Id,
                        Order = i + 1
                    };

                    
                    var newSets = new HashSet<CreateCompletedSet>();
                    for(int x=0; x < 4; x++)
                    {
                        var completedSet = new CreateCompletedSet()
                        {
                            Order = x + 1,
                            Reps = radom.Next(1,11),
                            Weight = radom.Next(20,101)
                        };
                        newSets.Add(completedSet);
                    }

                    completedExercise.Sets = newSets;
                    newExercises.Add(completedExercise);
                }

                await _completedWorkoutManagementService.CreateAsync(Guid.NewGuid(),userId, workoutName, "The best workout in my life.", radom.Next(1200,7201), date, newExercises);
        }

    }
}