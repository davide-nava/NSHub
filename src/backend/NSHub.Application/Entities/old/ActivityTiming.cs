using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ActivityTiming : BaseEntity
{
    public Guid ActivityManagementId { get; set; }

    public Guid ActivityProgressId { get; set; }

    public int Verso { get; set; }

    public DateTime CallStartDate { get; set; }

    public DateTime CallEndDate { get; set; }

    public int CallDuration { get; set; }

    public virtual ActivityProgress? ActivityProgress { get; set; }

    public virtual ActivityManagement? ActivityManagement { get; set; }
}
