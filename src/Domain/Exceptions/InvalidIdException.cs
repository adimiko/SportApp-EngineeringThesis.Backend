using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidIdException : DomainException
    {
        public InvalidIdException(string message)
            : base (DomainErrorCodes.General.InvalidId, message) {}
    }
}