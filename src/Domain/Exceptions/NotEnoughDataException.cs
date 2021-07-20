using Domain.Errors;

namespace Domain.Exceptions
{
    public class NotEnoughDataException : DomainException
    {
        public NotEnoughDataException(string message)
            : base (DomainErrorCodes.WorkoutsAnalysis.NotEnoughData, message) {}
    }
}