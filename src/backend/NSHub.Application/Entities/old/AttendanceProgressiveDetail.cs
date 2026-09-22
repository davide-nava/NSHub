using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceProgressiveDetail : BaseEntity
{
    public Guid AttendanceProgressiveId { get; set; }

    public Guid AttendanceBalanceId { get; set; }

    public int Order { get; set; }

    public PrintModeType PrintModeType { get; set; }

    public string MonthDays { get; set; } = null!;

    public string Months { get; set; } = null!;

    public string MonthWeeklyOccurrences { get; set; } = null!;

    public int PeriodCycles { get; set; }

    public PeriodType PeriodType { get; set; }

    public PlanningType PlanningType { get; set; }

    public DateTime ReferenceDate { get; set; }

    public string WeekDays { get; set; } = null!;

    public int AccountMinus { get; set; }

    public int AccountPlus { get; set; }

    public AccountMinusDayType AccountMinusDayType { get; set; }

    public AccountPlusDayType AccountPlusDayType { get; set; }

    public DateTime EndPeriodicity { get; set; }

    public int VisibleOnWebModeType { get; set; }

    public int GenerationModeType { get; set; }

    public int DayOutOfBounds { get; set; }

    public int HolidayCondition { get; set; }

    public string HolidayType { get; set; } = null!;

    public bool DefaultBalance { get; set; }

    public virtual AttendanceProgressive? AttendanceProgressive { get; set; }
}
