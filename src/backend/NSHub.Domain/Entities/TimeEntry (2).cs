using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class TimeEntry : AuditableTenantEntity
{
    public Guid? EmployeeId { get; protected set; }
    public DateTime WorkDate { get; protected set; }
    public TimeSpan? StartTime { get; protected set; }
    public TimeSpan? EndTime { get; protected set; }
    public int? BreakDurationMinutes { get; protected set; }
    public decimal TotalHoursWorked { get; protected set; }
    public bool IsNightWork { get; protected set; }
    public bool IsSundayWork { get; protected set; }
    public virtual Employee? Employee { get; protected set; }

    protected TimeEntry() { }

    public static TimeEntry Create()
    {
        return new TimeEntry();
    }
}
