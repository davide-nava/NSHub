using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Ticket : AuditableTenantEntity
{
    public Guid UserId { get; protected set; }
    public Guid? CustomerId { get; protected set; }
    public Guid? MachineId { get; protected set; }
    public Guid TicketStatusTypeId { get; protected set; }
    public string Title { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;
    public DateTime ClosingDate { get; protected set; }
    public DateTime OpeningDate { get; protected set; }
    public virtual Customer? Customer { get; protected set; }
    public virtual Machine? Machine { get; protected set; }
    public virtual TicketStatusType? TicketStatusType { get; protected set; }
    public virtual User? User { get; protected set; }

    private readonly List<TicketComment> _ticketComments = new();
    public virtual IReadOnlyCollection<TicketComment> TicketComments => _ticketComments.AsReadOnly();
    private readonly List<TicketIntervention> _ticketInterventions = new();
    public virtual IReadOnlyCollection<TicketIntervention> TicketInterventions => _ticketInterventions.AsReadOnly();
    private readonly List<TicketShipment> _ticketShipments = new();
    public virtual IReadOnlyCollection<TicketShipment> TicketShipments => _ticketShipments.AsReadOnly();
    private readonly List<TicketStatus> _ticketStatuses = new();
    public virtual IReadOnlyCollection<TicketStatus> TicketStatuses => _ticketStatuses.AsReadOnly();

    protected Ticket() { }

    public static Ticket Create(
        string title,
        string description,
        Guid userId,
        Guid ticketStatusTypeId,
        Guid? customerId = null,
        Guid? machineId = null,
        DateTime? openingDate = null)
    {
        return new Ticket
        {
            Title = title,
            Description = description,
            UserId = userId,
            TicketStatusTypeId = ticketStatusTypeId,
            CustomerId = customerId,
            MachineId = machineId,
            OpeningDate = openingDate ?? DateTime.UtcNow
        };
    }

    public void CloseTicket(DateTime? closingDate = null)
    {
        ClosingDate = closingDate ?? DateTime.UtcNow;
    }

    public void UpdateStatus(Guid newStatusTypeId)
    {
        TicketStatusTypeId = newStatusTypeId;
    }
}
