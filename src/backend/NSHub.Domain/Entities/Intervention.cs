using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Intervention : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;
    public DateTime? EndDate { get; protected set; }
    public DateTime StartDate { get; protected set; }
    public string? Notes { get; protected set; }
    public string Operator { get; protected set; } = string.Empty;
    public string Title { get; protected set; } = string.Empty;
    public Guid MachineId { get; protected set; }
    public virtual Machine? Machine { get; protected set; }

    private readonly List<InterventionAttachment> _interventionAttachments = new();
    public virtual IReadOnlyCollection<InterventionAttachment> InterventionAttachments => _interventionAttachments.AsReadOnly();
    private readonly List<InterventionUser> _interventionUsers = new();
    public virtual IReadOnlyCollection<InterventionUser> InterventionUsers => _interventionUsers.AsReadOnly();
    private readonly List<TicketIntervention> _ticketInterventions = new();
    public virtual IReadOnlyCollection<TicketIntervention> TicketInterventions => _ticketInterventions.AsReadOnly();

    protected Intervention() { }

    public static Intervention Create()
    {
        return new Intervention();
    }
}
