using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class TimesheetHeader : BaseEntity
{
    public Guid TimesheetId { get; set; }

    public Guid EmployeeId { get; set; }

    public DateOnly PeriodStartDate { get; set; }

    public DateOnly PeriodEndDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<TimesheetLine> TimesheetLines { get; set; } = [];
}
