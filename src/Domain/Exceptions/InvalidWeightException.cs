using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidWeightException : DomainException
    {
        public InvalidWeightException(string message)
            : base(DomainErrorCodes.CompletedSet.InvalidWeight, message) {}
    }
}