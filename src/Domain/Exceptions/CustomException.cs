using System;

namespace Domain.Exceptions
{
    public abstract class CustomException : Exception
    {
        public string Code { get; }

        protected CustomException(string code, string message) : base (message)
            => Code = code;

        protected CustomException(string code, string message, Exception innerException)
            : base(message, innerException)
            => Code = code;
    }
}