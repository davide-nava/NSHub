using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceRecalculationBodyGroup : BaseEntity
{
    public int Position { get; set; }

    public Guid AttendanceRecalculationGroupId { get; set; }

    public Guid AttendanceRecalculationId { get; set; }

    public int ExecutionTime { get; set; }

    public bool IsDeactivated { get; set; }

    public virtual AttendanceRecalculationGroup? AttendanceRecalculationGroup { get; set; }

    public virtual AttendanceRecalculation? AttendanceRecalculation { get; set; }
}
