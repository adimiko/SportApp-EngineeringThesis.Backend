namespace Domain.Exceptions
{
    public class InvalidMeasurementValueException : DomainException
    {
        public InvalidMeasurementValueException(string code, string message)
            : base(code, message) {}
    }
}