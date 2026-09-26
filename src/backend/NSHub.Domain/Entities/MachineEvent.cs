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
    /// Gets the event notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the machine event type identifier.
    /// </summary>
    public Guid MachineEventTypeId { get; protected set; }

    /// <summary>
    /// Gets the machine identifier.
    /// </summary>
    public Guid MachineId { get; protected set; }

    /// <summary>
    /// Gets the event date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; protected set; }
}
