// <copyright file="MachineEvent.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an event associated with a machine.
/// </summary>
public class MachineEvent : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the event notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the machine event type identifier.
    /// </summary>
    public Guid MachineEventTypeId { get; set; }

    /// <summary>
    /// Gets or sets the machine identifier.
    /// </summary>
    public Guid MachineId { get; set; }

    /// <summary>
    /// Gets or sets the event date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; set; }
}
