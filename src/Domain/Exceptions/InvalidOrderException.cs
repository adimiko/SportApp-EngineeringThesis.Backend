using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidOrderException : DomainException
    {
        public InvalidOrderException(string message)
            : base(DomainErrorCodes.General.InvalidOrder, message){}
    }
}