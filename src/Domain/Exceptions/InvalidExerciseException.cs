using Domain.Errors;

namespace Domain.Exceptions
{
    public class InvalidExerciseException : DomainException
    {
        public InvalidExerciseException(string code, string message)
            : base(code, message){}
    }
}