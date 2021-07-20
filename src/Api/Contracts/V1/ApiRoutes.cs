namespace Api.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Version = "v1";

        public static class Account
        {
            public const string Route = Version + "/account";
            public const string GetAsync = Route;
            public const string ChangePasswordAsync = Route + "/change-password";
            public const string DeleteAsync = Route;
        }

        public static class Identity
        {
            public const string Route = Version + "/identity";
            public const string LoginAsync = Route + "/login";
            public const string RegisterAsync = Route + "/register";
        }
        public static class ExerciseInfo
        {
            public const string Route = Version + "/exercise-info";
            public const string GetAsync = Route + "/{id}";
            public const string BrowseWithoutArchiveAsync = Route;
            public const string BrowseArchiveAsync = Route + "/archive";
            public const string CreateAsync = Route;
            public const string UpdateAsync = Route + "/{id}";
            public const string ArchiveAsync = Route + "/{id}/archive";
            public const string RestoreAsync = Route + "/{id}/restore";
        }

        public static class BodyMeasurement
        {
            public const string Route = Version + "/body-measurements";
            public const string GetAsync = Route + "/{id}";
            public const string BrowseAsync = Route;
            public const string CreateAsync = Route;
            public const string UpdateAsync = Route + "/{id}";
            public const string DeleteAsync = Route + "/{id}";
        }

        public static class SampleWorkoutRoutine
        {
            public const string Route = Version + "/sample-workout-routines";
            public const string GetAsync = Route + "/{id}";
            public const string BrowseWithoutArchiveAsync = Route;
            public const string BrowseArchiveAsync = Route + "/archive";
            public const string CreateAsync = Route;
            public const string UpdateAsync = Route + "/{id}";
            public const string ArchiveAsync = Route + "/{id}/archive";
            public const string RestoreAsync = Route + "/{id}/restore";
        }

        public static class CustomWorkoutRoutine
        {
            public const string Route = Version + "/custom-workout-routines";
            public const string GetAsync = Route + "/{id}";
            public const string BrowseWithoutArchiveAsync = Route;
            public const string BrowseArchiveAsync = Route + "/archive";
            public const string CreateAsync = Route;
            public const string UpdateAsync = Route + "/{id}";
            public const string ArchiveAsync = Route + "/{id}/archive";
            public const string RestoreAsync = Route + "/{id}/restore";
        }

        public static class CompletedWorkout
        {
            public const string Route = Version + "/completed-workouts";
            public const string GetAsync = Route + "/{id}";
            public const string BrowseAsync = Route;
            public const string SaveAsync = Route;
            public const string DeleteAsync = Route + "/{id}";
        }

        public static class WorkoutsStats
        {
            public const string Route = Version + "/workouts-stats";
            public const string GetGlobalWorkoutsStatsAsync = Route + "/global";
            public const string GetWorkoutsStatsCurrentWeekAsync = Route + "/current-week";
            public const string GetWorkoutsStatsCurrentMonthAsync = Route + "/current-month";
            public const string GetWorkoutsStatsCurrentYearAsync = Route + "/current-year";

        }

        public static class WorkoutsAnalysis
        {
            public const string Route = Version + "/workouts-analysis";
            public const string GetWorkoutsAnalysisFromTheLastMonthAsync = Route + "/last-month";
        }
    }
}