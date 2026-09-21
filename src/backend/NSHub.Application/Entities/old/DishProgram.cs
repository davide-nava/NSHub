using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Wordprocessing;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class DishProgram : BaseEntity
{
    public Guid DishId { get; set; }

    public DateTime ReservationLimitMinutes { get; set; }

    public int ReservationLimitDays { get; set; }

    public DateTime AnnullableUntilMinutes { get; set; }

    public int AnnullableUntilDays { get; set; }

    public PlanningType PlanningType { get; set; }

    public virtual Dish? Dish { get; set; }

    public string MonthDays { get; set; } = null!;

    public string Months { get; set; } = null!;

    public string WeekDays { get; set; } = null!;

    public string MonthWeeklyOccurrences { get; set; } = null!;

    public PeriodType PeriodType { get; set; }

    public int PeriodCycles { get; set; }

    public DateTime ReferenceDate { get; set; }

    public DateTime EndPeriodicity { get; set; }

    public int DayOutOfBounds { get; set; }

    public Guid MealTypeId { get; set; }

    public int HolidayCondition { get; set; }

    public string HolidayType { get; set; } = null!;
    public virtual MealType? MealType { get; set; }

}
