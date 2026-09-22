using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class TimesheetLine : BaseEntity
{

    public Guid TimesheetId { get; set; }

    public DateOnly WorkDate { get; set; }

    public decimal HoursWorked { get; set; }

    public Guid? BusinessUnitId { get; set; }

    public string? Description { get; set; }

    public virtual BusinessUnit? BusinessUnit { get; set; }

    public virtual TimesheetHeader Timesheet { get; set; } = null!;
}
