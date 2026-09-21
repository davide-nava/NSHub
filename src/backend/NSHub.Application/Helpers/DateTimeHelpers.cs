// <copyright file="DateTimeHelpers.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Helpers;

public static class DateTimeHelpers
{
    public static DateTime GetLastSunday(DateTime data)
    {
        DateTime lastSunday = new(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month), data.Hour, data.Minute, data.Second, DateTimeKind.Local);

        for (var i = DateTime.DaysInMonth(data.Year, data.Month); i > 10; i--)
        {
            if (lastSunday.DayOfWeek == DayOfWeek.Sunday)
            {
                break;
            }

            lastSunday = lastSunday.AddDays(-1);
        }

        return lastSunday;
    }

    public static DateTime GetLastSundayOfMonth(int year, int month)
    {
        DateTime date = new(year, month, 1, 0, 0, 0, DateTimeKind.Local);
        date = date.AddMonths(1).AddDays(-1);
        while (date.DayOfWeek != DayOfWeek.Sunday)
        {
            date = date.AddDays(-1);
        }

        return date;
    }
}
