using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class JobPlanning : BaseEntity
{
    public IEnumerable<GuidList> JobLevels { get; set; }

    public Guid ResourceId { get; set; }

    public Guid ResourceTypeId { get; set; }

    public int JobMinutes { get; set; }

    public string MonthDays { get; set; } = null!;

    public string Months { get; set; } = null!;

    public string MonthWeeklyOccurrences { get; set; } = null!;

    public int PeriodCycles { get; set; }

    public PeriodType PeriodType { get; set; }

    public PlanningType PlanningType { get; set; }

    public DateTime ReferenceDate { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string WeekDays { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public DateTime ValidFrom { get; set; }

    public DateTime ValidUntil { get; set; }

    public AmountType AmountType { get; set; }

    public decimal AmountValue { get; set; }

    public DateTime EndPeriodicity { get; set; }

    // TODO: Check type
    public int DayOutOfBounds { get; set; }

    // TODO: Check type
    public int HolidayCondition { get; set; }

    public string HolidayType { get; set; } = null!;
}
