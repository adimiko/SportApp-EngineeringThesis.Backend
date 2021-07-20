using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidTokenExpiresException : DomainException
    {
        public InvalidTokenExpiresException(string message)
            : base(DomainErrorCodes.Token.InvalidExpires, message) {}
    }
}