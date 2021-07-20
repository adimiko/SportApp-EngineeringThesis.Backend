namespace Domain.Errors
{
    public static class DomainErrorCodes
    {
        public static class General
        {
            public static string InvalidId => "invalid_id";
            public static string InvalidName => "invalid_name";
            public static string InvalidOrder => "invalid_order";
        }
        public static class Token
        {
            public static string InvalidJWT => "invalid_jwt";
            public static string InvalidExpires => "invalid_expires";
        }

        public static class ExerciseInfo
        {

        }

        public static class Account
        {
            public static string InvalidEmail => "invalid_email";
            public static string InvalidPassword => "invalid_password";
            public static string InvalidSalt => "invalid_salt";
        }

        public static class BodyMeasurement
        {
            public static string InvalidWeight => "invalid_weight";
            public static string InvalidHeight => "invalid_height";
            public static string InvalidArm => "invalid_arm";
            public static string InvalidChest => "invalid_chest";
            public static string InvalidWaist => "invalid_waist";
            public static string InvalidHip => "invalid_hip";
            public static string InvalidThigh => "invalid_thigh";
            public static string InvalidCalf => "invalid_calf";
        }

        public static class WorkoutRoutine
        {
            public static string ExerciseDoesNotExist => "exercise_does_not_exist";
        }

        public static class Exercise
        {
            public static string InvalidNumberOfSets => "invalid_number_of_sets";
        }

        public static class CompletedWorkout
        {
            public static string InvalidDuration => "invalid_duration";
        }

        public static class CompletedSet
        {
            public static string InvalidReps => "invalid_reps";
            public static string InvalidWeight => "invalid_weight";
        }

        public static class WorkoutsAnalysis
        {
            public static string NotEnoughData => "not_enough_data";
        }
    }
}