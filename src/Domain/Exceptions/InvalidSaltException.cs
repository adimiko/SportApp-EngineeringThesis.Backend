using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidSaltException : DomainException
    {
        public InvalidSaltException(string message)
            : base(DomainErrorCodes.Account.InvalidSalt, message) {}
    }
}