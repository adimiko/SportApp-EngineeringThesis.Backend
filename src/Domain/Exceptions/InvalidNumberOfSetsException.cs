using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidNumberOfSetsException : DomainException
    {
        public InvalidNumberOfSetsException(string message)
            : base(DomainErrorCodes.Exercise.InvalidNumberOfSets, message){}
    }
}