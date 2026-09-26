// <copyright file="TicketIntervention.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the association between a ticket and an intervention.
/// </summary>
public class TicketIntervention : AuditableTenantEntity
{
    /// <summary>
    /// Gets the intervention identifier.
    /// </summary>
    public Guid InterventionId { get; protected set; }

    /// <summary>
    /// Gets the ticket identifier.
    /// </summary>
    public Guid TicketId { get; protected set; }

    /// <summary>
    /// Gets the intervention date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the intervention notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the associated intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Intervention? Intervention { get; protected set; }

    /// <summary>
    /// Gets the associated ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Ticket? Ticket { get; protected set; }
}
