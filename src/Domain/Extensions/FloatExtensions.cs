namespace Domain.Extensions
{
    public static class FloatExtensions
    {
        public static bool IsEquelsOrBelowZero(this float value)
        {
           if(value <= 0) return true;

            return false;
        }

        public static bool IsAboveZero(this float value)
        {
            return !IsEquelsOrBelowZero(value);
        }
    }
}