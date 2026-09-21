using System;

namespace PlanetHub.ApplicationCore.Entities;

public class ShiftCoverage : BaseEntity
{
    public int Quantity { get; set; }

    public Guid ShiftNeedId { get; set; }

    public PlanningType PlanningType { get; set; }

    public string MonthDays { get; set; } = null!;

    public string Months { get; set; } = null!;

    public string WeekDays { get; set; } = null!;

    public string MonthWeeklyOccurrences { get; set; } = null!;

    public PeriodType PeriodType { get; set; }

    // TODO: Check type
    public int PeriodCycles { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public DateTime ReferenceDate { get; set; }

    public DateTime EndPeriodicity { get; set; }

    // TODO: Check type
    public int DayOutOfBounds { get; set; }

    // TODO: Check type
    public int HolidayCondition { get; set; }

    public string HolidayType { get; set; } = null!;
}
