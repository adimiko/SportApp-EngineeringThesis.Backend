using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidPasswordException : DomainException
    {
        public InvalidPasswordException(string message)
            : base (DomainErrorCodes.Account.InvalidPassword, message) {}
    }
}