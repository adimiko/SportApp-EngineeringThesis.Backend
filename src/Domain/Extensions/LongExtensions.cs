namespace Domain.Extensions
{
    public static class LongExtensions
    {
        public static bool IsEquelsOrBelowZero(this long value)
            => value <= 0 ? true : false;
    }
}