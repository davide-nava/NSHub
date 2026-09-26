// <copyright file="MachineAxisEncoder.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a machine axis encoder.
/// </summary>
public class MachineAxisEncoder : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the machine axis identifier.
    /// </summary>
    public string Axis { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the encoder code.
    /// </summary>
    public string Code { get; set; } = string.Empty;
}
