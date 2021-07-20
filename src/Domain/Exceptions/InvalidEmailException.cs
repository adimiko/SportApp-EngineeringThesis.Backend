using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidEmailException : DomainException
    {
        public InvalidEmailException(string message)
            : base (DomainErrorCodes.Account.InvalidEmail, message) {}
    }
}