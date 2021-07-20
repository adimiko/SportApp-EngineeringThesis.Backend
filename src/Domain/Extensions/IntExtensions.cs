namespace Domain.Extensions
{
    public static class IntExtensions
    {
        public static bool IsEquelsOrBelowZero(this int value)
        {
           if(value <= 0) return true;

            return false;
        }

        public static bool IsAboveZero(this int value)
        {
            return !IsEquelsOrBelowZero(value);
        }
    }
}