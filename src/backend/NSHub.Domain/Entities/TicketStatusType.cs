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
    /// Gets or sets a value indicating whether the status represents a closed ticket.
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// Gets or sets the tickets associated with this status type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Ticket> Tickets { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the ticket status history entries associated with this status type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketStatus> TicketStatuses { get; set; }
        = [];
}
