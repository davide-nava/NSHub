using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class KleSynchronizeIncidentContent : BaseEntity
{
    public string Content { get; set; } = null!;

    public Guid DeclarationDetailId { get; set; }

    public Guid SynchronizeIncidentId { get; set; }

    public RecordType RecordType { get; set; }

    public CommunicationType CommunicationType { get; set; }

    public StatusType StatusType { get; set; }

    public string StoryId { get; set; } = null!;

    public DateTime Creation { get; set; }

    public Guid SynchronizeConfirmedId { get; set; }

    public Guid CompletedByCompanyId { get; set; }

    public bool AvailableConfirmed { get; set; }

    public virtual CompletedByCompany? CompletedByCompany { get; set; }
    public virtual SynchronizeConfirmed? SynchronizeConfirmed { get; set; }
    public virtual SynchronizeIncident? SynchronizeIncident { get; set; }
    public virtual DeclarationDetail? DeclarationDetail { get; set; }
}
