using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidNameException : DomainException
    {
        public InvalidNameException(string message)
            : base(DomainErrorCodes.General.InvalidName, message){}
    }
}