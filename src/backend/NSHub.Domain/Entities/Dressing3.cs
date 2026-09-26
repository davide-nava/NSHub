// <copyright file="Dressing3.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a dressing configuration.
/// </summary>
public class Dressing3 : AuditableTenantEntity
{
    /// <summary>
    /// Gets a value indicating whether the high-frequency spindle is enabled.
    /// </summary>
    public bool IsHfSpindle { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the standard spindle is enabled.
    /// </summary>
    public bool IsNormalSpindle { get; protected set; }

    /// <summary>
    /// Gets the working speed.
    /// </summary>
    public decimal WorkSpeed { get; protected set; }

    /// <summary>
    /// Gets the high-frequency spindle speed.
    /// </summary>
    public decimal HfSpeed { get; protected set; }

    /// <summary>
    /// Gets the standard spindle speed.
    /// </summary>
    public decimal NormalSpeed { get; protected set; }
}
