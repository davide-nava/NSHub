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
    /// Gets or sets a value indicating whether the high-frequency spindle is enabled.
    /// </summary>
    public bool IsHfSpindle { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the standard spindle is enabled.
    /// </summary>
    public bool IsNormalSpindle { get; set; }

    /// <summary>
    /// Gets or sets the working speed.
    /// </summary>
    public decimal WorkSpeed { get; set; }

    /// <summary>
    /// Gets or sets the high-frequency spindle speed.
    /// </summary>
    public decimal HfSpeed { get; set; }

    /// <summary>
    /// Gets or sets the standard spindle speed.
    /// </summary>
    public decimal NormalSpeed { get; set; }
}
