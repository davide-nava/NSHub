using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class JobEntrySuspensionPeriod : BaseEntity
{
    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public Guid JobEntryId { get; set; }

    public virtual JobEntry? JobEntry { get; set; }
}
