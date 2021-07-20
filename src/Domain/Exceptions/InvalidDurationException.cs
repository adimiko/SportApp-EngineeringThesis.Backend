using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidDurationException : DomainException
    {
        public InvalidDurationException(string message)
            : base (DomainErrorCodes.CompletedWorkout.InvalidDuration, message) {}
    }
}