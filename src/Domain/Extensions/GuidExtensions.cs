using System;

namespace Domain.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid id)
            => id == Guid.Empty;
    }
}