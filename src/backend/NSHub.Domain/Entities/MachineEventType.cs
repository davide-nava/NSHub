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
    /// Gets or sets the event type code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the event type description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the machine events associated with this event type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<MachineEvent> MachineEvents { get; set; }
        = [];
}
