namespace Application.Errors
{
    public static class ServiceErrorCodes
    {
        public static class General
        {
            public static string AccessDenied => "access_denied";
        }
        public static class Account
        {
            public static string AlreadyExists => "account_already_exists";
            public static string InvalidCredentials => "invalid_credentials";
            public static string InvalidPasswordLength => "invalid_password_length";
            public static string InvalidConfirmPassword => "invalid_confirm_password";
            public static string InvalidOldPassword => "invalid_old_password";
            public static string FirstAdminAlreadyExists => "first_admin_already_exists";

        }


        public static class ExerciseInfo
        {
            public static string NotFound => "exercise_info_not_found";
            public static string AlreadyExists => "exercise_info_already_exists";
        }

        public static class BodyMeasurement
        {
            public static string NotFound => "body_measurement_not_found";
            public static string AlreadyExists => "body_measurement_already_exists";
        }

        public static class SampleWorkoutRoutine
        {
            public static string NotFound => "sample_workout_routine_not_found";
            public static string AlreadyExists => "sample_workout_routine_already_exists";
        }

        public static class CustomWorkoutRoutine
        {
            public static string NotFound => "custom_workout_routine_not_found";
            public static string AlreadyExists => "custom_workout_routine_already_exists";
        }

        public static class CompletedWorkout
        {
            public static string NotFound => "completed_workout_not_found";
            public static string AlreadyExists => "completed_workout_already_exists";
        }
    }
}