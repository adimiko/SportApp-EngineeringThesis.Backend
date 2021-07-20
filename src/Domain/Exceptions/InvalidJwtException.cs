using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidJwtException : DomainException
    {
        public InvalidJwtException(string message)
            : base(DomainErrorCodes.Token.InvalidJWT, message) {}
    }
}