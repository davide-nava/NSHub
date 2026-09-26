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
    /// Gets or sets the machine axis.
    /// </summary>
    public string Axis { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the screw code.
    /// </summary>
    public string Code { get; set; } = string.Empty;
}
