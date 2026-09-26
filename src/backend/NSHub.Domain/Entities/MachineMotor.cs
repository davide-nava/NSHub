// <copyright file="MachineMotor.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a machine motor.
/// </summary>
public class MachineMotor : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the machine axis.
    /// </summary>
    public string Axis { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the motor code.
    /// </summary>
    public string Code { get; set; } = string.Empty;
}
