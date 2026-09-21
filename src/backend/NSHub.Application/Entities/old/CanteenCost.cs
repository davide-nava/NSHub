using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CanteenCost : BaseEntity
{

    public Guid EmployeeId { get; set; }

    public DateTime Date { get; set; }

    public decimal TotalCost { get; set; }

    public decimal TotalCostBaseCurrency { get; set; }

    public Guid FormulaId { get; set; }

    public decimal EmployeeCost { get; set; }

    public decimal EmployeeCostBaseCurrency { get; set; }

    public Guid CanteenReservationMenuId { get; set; }

    public Guid CurrencyId { get; set; }

    public decimal ExchangeRate { get; set; }

    public Guid AttendanceTimeId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual Formula? Formula { get; set; }
    public virtual CanteenReservationMenu? CanteenReservationMenu { get; set; }
    public virtual Currency? Currency { get; set; }
    public virtual AttendanceTime? AttendanceTime { get; set; }
}
