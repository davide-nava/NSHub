// <copyright file="MachineEventType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a machine event type.
/// </summary>
public class MachineEventType : AuditableTenantEntity
{
    /// <summary>
    /// Gets the event type code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the event type description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the machine events associated with this event type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<MachineEvent> MachineEvents { get; protected set; }
        = new List<MachineEvent>();
}
