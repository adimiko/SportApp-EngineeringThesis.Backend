using Domain.Exceptions;

namespace Application.Exceptions
{
    public class ServiceException : CustomException
    {
        public ServiceException(string code, string message)
            : base(code, message) {}
    }
}