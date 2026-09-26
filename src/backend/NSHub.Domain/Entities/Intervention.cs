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
    /// Gets or sets the intervention description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the intervention end date.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Gets or sets the intervention start date.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the operator responsible for the intervention.
    /// </summary>
    public string Operator { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the intervention title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the machine identifier.
    /// </summary>
    public Guid MachineId { get; set; }

    /// <summary>
    /// Gets or sets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; set; }

    /// <summary>
    /// Gets or sets the attachments associated with this intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<InterventionAttachment> InterventionAttachments { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the ticket associations related to this intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketIntervention> TicketInterventions { get; set; }
        = [];
}
