using System;

namespace NSHub.ApplicationCore.Entities;

public class ShiftRequest : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public Guid WorkingTimeGroupId { get; set; }

    public Guid WorkingTimeId { get; set; }

    // TODO: Check type
    public int Needs { get; set; }

    public Guid ShiftRequestTypeId { get; set; }

    public virtual ShiftRequestType? ShiftRequestType { get; set; }

    public string AttendancePlansId { get; set; } = null!;

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual WorkingTimeGroup? WorkingTimeGroup { get; set; }
    public virtual WorkingTime? WorkingTime { get; set; }
}
