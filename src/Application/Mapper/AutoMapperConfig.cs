using Application.Mapper.Configurations;
using AutoMapper;

namespace Application.Mapper
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMapForToken();
                cfg.CreateMapForAccount();
                cfg.CreateMapForExerciseInfo();
                cfg.CreateMapForBodyMeasurement();
                cfg.CreateMapForWorkoutRoutine();
                cfg.CreateMapForSampleWorkoutRoutine();
                cfg.CreateMapForCustomWorkoutRoutine();
                cfg.CreateMapForCompletedWorkout();
                cfg.CreateMapForWorkoutsStats();
                cfg.CreateMapForWorkoutsAnalysis();
            }).CreateMapper();
    }
}