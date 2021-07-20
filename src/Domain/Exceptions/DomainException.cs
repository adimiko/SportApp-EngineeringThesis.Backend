

namespace Domain.Exceptions
{
    public class DomainException : CustomException
    {
        public DomainException(string code, string message)
            : base(code, message) {}
    }
}