// <copyright file="TicketStatusType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class TicketStatusType : AuditableTenantEntity
{
    public bool IsClosed { get; protected set; }

    private readonly List<Ticket> _tickets = new();
    public virtual IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();
    private readonly List<TicketStatus> _ticketStatuses = new();
    public virtual IReadOnlyCollection<TicketStatus> TicketStatuses => _ticketStatuses.AsReadOnly();

    protected TicketStatusType() { }

    public static TicketStatusType Create()
    {
        return new TicketStatusType();
    }
}
