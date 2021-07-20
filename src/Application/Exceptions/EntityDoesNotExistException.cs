namespace Application.Exceptions
{
    public class EntityDoesNotExistException : ServiceException
    {
        public EntityDoesNotExistException(string code, string message)
            : base(code, message) {}
    }
}