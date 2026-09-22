using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendancePlan : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime AttendanceDate { get; set; }

    public Guid WorkingTimeGroupId { get; set; }

    public Guid WorkingTimesId { get; set; }

    public int Needs { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual WorkingTimeGroup? WorkingTimeGroup { get; set; }
    public virtual WorkingTimes? WorkingTimes { get; set; }
}
