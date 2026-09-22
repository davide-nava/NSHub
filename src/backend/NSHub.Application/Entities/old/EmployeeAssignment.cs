using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class EmployeeAssignment : BaseEntity
{
    public int EmployeeAssignmentId { get; set; }

    public int EmployeeId { get; set; }

    public int JobPositionId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal BaseSalaryAmount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual JobPosition JobPosition { get; set; } = null!;
}
