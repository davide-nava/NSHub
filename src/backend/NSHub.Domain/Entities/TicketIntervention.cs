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
    /// Gets or sets the intervention identifier.
    /// </summary>
    public Guid InterventionId { get; set; }

    /// <summary>
    /// Gets or sets the ticket identifier.
    /// </summary>
    public Guid TicketId { get; set; }

    /// <summary>
    /// Gets or sets the intervention date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the intervention notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the associated intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Intervention? Intervention { get; set; }

    /// <summary>
    /// Gets or sets the associated ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Ticket? Ticket { get; set; }
}
