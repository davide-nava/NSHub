using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class Reminder : BaseEntity
{
    public Guid RecordId { get; set; }

    public Guid TableId { get; set; }

    public virtual Table? Table { get; set; }
    public virtual Record? Record { get; set; }

    public DateTime InputDate { get; set; }

    public DateTime Date { get; set; }

    public Guid TitleId { get; set; }

    public virtual TranslationGroup? Title { get; set; }

    public Guid TextId { get; set; }

    public virtual TranslationGroup? Text { get; set; }

    public PriorityType PriorityType { get; set; }

    public string ExchangeUniqueId { get; set; } = null!;

    public PlanningType PlanningType { get; set; }

    public string MonthDays { get; set; } = null!;

    public string Months { get; set; } = null!;

    public string WeekDays { get; set; } = null!;

    public string MonthWeeklyOccurrences { get; set; } = null!;

    public PeriodType PeriodType { get; set; }

    // TODO: Check type
    public int PeriodCycles { get; set; }

    public DateTime ReferenceDate { get; set; }

    public DateTime EndPeriodicity { get; set; }

    // TODO: Check type
    public int DayOutOfBounds { get; set; }

    public DateTime CreationDateTime { get; set; }

    // TODO: Check type
    public int HolidayCondition { get; set; }

    public string HolidayType { get; set; } = null!;

    public virtual Employee? CreationEmployee { get; set; }

    public Guid CreationEmployeeId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


}
