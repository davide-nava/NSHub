using System;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendanceProgressiveLoading : BaseEntity
{
    public Guid AttendanceProgressiveId { get; set; }

    public Guid AccountId { get; set; }

    public decimal Value { get; set; }

    public string MonthDays { get; set; } = null!;

    public string Months { get; set; } = null!;

    public string MonthWeeklyOccurrences { get; set; } = null!;

    public int PeriodCycles { get; set; }

    public PeriodType PeriodType { get; set; }

    public PlanningType PlanningType { get; set; }

    public DateTime ReferenceDate { get; set; }

    public string WeekDays { get; set; } = null!;

    public DateTime EndPeriodicity { get; set; }

    public int DayOutOfBounds { get; set; }

    public int HolidayCondition { get; set; }

    public string HolidayType { get; set; } = null!;

    public virtual AttendanceProgressive? AttendanceProgressive { get; set; }
    public virtual Account? Account { get; set; }

}
