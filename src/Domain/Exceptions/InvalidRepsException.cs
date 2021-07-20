using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidRepsException : DomainException
    {
        public InvalidRepsException(string message)
            : base(DomainErrorCodes.CompletedSet.InvalidReps, message) {}
    }
}