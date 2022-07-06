namespace GM.Data.Helpers;

public static class TimeHelper
{
    public static long NowSeconds()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    public static DateTime Now()
    {
        return DateTime.UtcNow.TruncateMilliseconds();
    }

    public static DateTime DateNow()
    {
        return DateTime.Now.Date;
    }

    public static DateTimeOffset Now(string timeZoneId)
    {
        return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, timeZoneId);
    }

    public static DateTime TruncateSeconds(this DateTime dateTime)
    {
        return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerMinute));
    }

    public static DateTime TruncateMilliseconds(this DateTime dateTime)
    {
        return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));
    }

    public static DateTimeOffset TruncateTime(this DateTimeOffset dateTimeOffset)
    {
        return new DateTimeOffset(dateTimeOffset.Date, dateTimeOffset.Offset);
    }

    public static DateTime ToUtc(this DateTime dateTime, string sourceTimeZoneId = "Asia/Ho_Chi_Minh")
    {
        if (dateTime.Kind == DateTimeKind.Utc)
        {
            return dateTime;
        }

        TimeZoneInfo sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZoneId);

        return TimeZoneInfo.ConvertTimeToUtc(dateTime, sourceTimeZone);
    }
}