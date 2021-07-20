using System;

namespace Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FormatToYearMonthDay(this DateTime date)
            => date = new DateTime(date.Year, date.Month, date.Day);

        public static DateTime GetTheWeekStartDate()
        {
            int x = Convert.ToInt32(DateTime.UtcNow.DayOfWeek);
            if(x == 0) x = 7;
            return DateTime.UtcNow.AddDays(-x + 1).Date;
        }

        public static DateTime GetTheMonthStartDate()
            => new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);

        public static DateTime GetTheYearStartDate()
            => new DateTime(DateTime.UtcNow.Year, 1, 1);
    }
}