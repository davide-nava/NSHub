// <copyright file="TicketStatusType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a ticket status type.
/// </summary>
public class TicketStatusType : AuditableTenantEntity
{
    /// <summary>
    /// Gets a value indicating whether the status represents a closed ticket.
    /// </summary>
    public bool IsClosed { get; protected set; }

    /// <summary>
    /// Gets the tickets associated with this status type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Ticket> Tickets { get; protected set; }
        = new List<Ticket>();

    /// <summary>
    /// Gets the ticket status history entries associated with this status type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketStatus> TicketStatuses { get; protected set; }
        = new List<TicketStatus>();
}
