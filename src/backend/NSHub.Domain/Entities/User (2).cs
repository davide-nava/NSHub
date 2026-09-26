using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class User : AuditableEntity
{
    public Guid? CurrentTenantId { get; protected set; }
    public bool IsActive { get; protected set; }
    public string? AspNetUserId { get; protected set; }
    public string? Email { get; protected set; }
    public virtual AspNetUsers? AspNetUser { get; protected set; }
    public virtual Tenant? CurrentTenant { get; protected set; }

    private readonly List<InterventionUser> _interventionUsers = new();
    public virtual IReadOnlyCollection<InterventionUser> InterventionUsers => _interventionUsers.AsReadOnly();
    private readonly List<Shipment> _shipments = new();
    public virtual IReadOnlyCollection<Shipment> Shipments => _shipments.AsReadOnly();
    private readonly List<Ticket> _tickets = new();
    public virtual IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();
    private readonly List<TicketComment> _ticketComments = new();
    public virtual IReadOnlyCollection<TicketComment> TicketComments => _ticketComments.AsReadOnly();
    private readonly List<TicketStatus> _ticketStatuses = new();
    public virtual IReadOnlyCollection<TicketStatus> TicketStatuses => _ticketStatuses.AsReadOnly();

    protected User() { }

    public static User Create()
    {
        return new User();
    }
}
