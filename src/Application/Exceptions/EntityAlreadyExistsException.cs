namespace Application.Exceptions
{
    public class EntityAlreadyExistsException : ServiceException
    {
        public EntityAlreadyExistsException(string code, string message)
            : base(code, message) {}
    }
}