namespace NSHub.Infrastructure.Services;

using NSHub.Application.Common.Interfaces;

public sealed class DateTimeProvider : IDateTimeProvider
{
    private static readonly TimeZoneInfo SwissTimeZone = TimeZoneInfo.FindSystemTimeZoneById(
        OperatingSystem.IsWindows() ? "W. Europe Standard Time" : "Europe/Zurich");

    public DateTime UtcNow => DateTime.UtcNow;

    public DateTime TodayUtc => DateTime.UtcNow.Date;

    public DateTime ToSwissTime(DateTime utcDateTime)
    {
        var utc = utcDateTime.Kind == DateTimeKind.Utc
            ? utcDateTime
            : DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);

        return TimeZoneInfo.ConvertTimeFromUtc(utc, SwissTimeZone);
    }

    public DateTime ToUtc(DateTime swissDateTime)
    {
        var unspecified = DateTime.SpecifyKind(swissDateTime, DateTimeKind.Unspecified);
        return TimeZoneInfo.ConvertTimeToUtc(unspecified, SwissTimeZone);
    }
}
