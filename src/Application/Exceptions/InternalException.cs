using System;
using Domain.Exceptions;

namespace Application.Exceptions
{
    public class InternalException : CustomException
    {
        public InternalException(string code, string message, Exception innerException)
            : base(code, message, innerException) {}
    }
}