// <copyright file="Intervention.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a maintenance or service intervention.
/// </summary>
public class Intervention : AuditableTenantEntity
{
    /// <summary>
    /// Gets the intervention description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the intervention end date.
    /// </summary>
    public DateTime? EndDate { get; protected set; }

    /// <summary>
    /// Gets the intervention start date.
    /// </summary>
    public DateTime StartDate { get; protected set; }

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the operator responsible for the intervention.
    /// </summary>
    public string Operator { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the intervention title.
    /// </summary>
    public string Title { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the machine identifier.
    /// </summary>
    public Guid MachineId { get; protected set; }

    /// <summary>
    /// Gets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; protected set; }

    /// <summary>
    /// Gets the attachments associated with this intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<InterventionAttachment> InterventionAttachments { get; protected set; }
        = new List<InterventionAttachment>();

    /// <summary>
    /// Gets the ticket associations related to this intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketIntervention> TicketInterventions { get; protected set; }
        = new List<TicketIntervention>();
}
