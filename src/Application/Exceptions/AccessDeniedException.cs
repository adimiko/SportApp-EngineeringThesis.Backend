using Application.Errors;

namespace Application.Exceptions
{
    public class AccessDeniedException : ServiceException
    {
        public AccessDeniedException(string message)
            : base(ServiceErrorCodes.General.AccessDenied, message) {}
    }
}