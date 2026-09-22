using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class ReminderResource : BaseEntity
{

    public Guid ReminderId { get; set; }

    public Guid ResourceId { get; set; }

    public bool IsShown { get; set; }

    public bool IsManaged { get; set; }

    public bool IsPinned { get; set; }

    public NotificationStateType NotificationStateType { get; set; }

    public bool DeleteForAll { get; set; }

    public virtual Reminder? Reminder { get; set; }
    public virtual Resource? Resource { get; set; }
}
