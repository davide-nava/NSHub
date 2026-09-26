// <copyright file="MachineScrew.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a machine screw.
/// </summary>
public class MachineScrew : AuditableTenantEntity
{
    /// <summary>
    /// Gets the machine axis.
    /// </summary>
    public string Axis { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the screw code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;
}
