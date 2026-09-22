using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceRecalculationBody : BaseEntity
{
    public int Position { get; set; }

    public Guid RecalculationId { get; set; }

    public Guid AccountId { get; set; }

    public Guid FormulaId { get; set; }

    public virtual Recalculation? Recalculation { get; set; }
    public virtual Account? Account { get; set; }
    public virtual Formula? Formula { get; set; }


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

    public Guid VerticalFormulaId { get; set; }

    public string VerticalFilter { get; set; } = null!;

    public Guid CompensationId { get; set; }

    public bool IsDeactivated { get; set; }

    public Guid HolidayConditionId { get; set; }

    public string HolidayType { get; set; } = null!;

    public virtual VerticalFormula? VerticalFormula { get; set; }
    public virtual Compensation? Compensation { get; set; }
    public virtual HolidayCondition? HolidayCondition { get; set; }


    public virtual AttendanceRecalculation? AttendanceRecalculation { get; set; }
}
