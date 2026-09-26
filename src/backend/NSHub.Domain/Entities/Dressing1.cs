// <copyright file="Dressing1.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a dressing configuration.
/// </summary>
public class Dressing1 : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the X coordinate.
    /// </summary>
    public decimal X { get; set; }

    /// <summary>
    /// Gets or sets the Y coordinate.
    /// </summary>
    public decimal Y { get; set; }

    /// <summary>
    /// Gets or sets the Z coordinate.
    /// </summary>
    public decimal Z { get; set; }

    /// <summary>
    /// Gets or sets the V coordinate.
    /// </summary>
    public decimal V { get; set; }

    /// <summary>
    /// Gets or sets the W coordinate.
    /// </summary>
    public decimal W { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether position 1 is enabled.
    /// </summary>
    public bool IsPos1 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether position 2 is enabled.
    /// </summary>
    public bool IsPos2 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether position 3 is enabled.
    /// </summary>
    public bool IsPos3 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether cycle 1 is enabled.
    /// </summary>
    public bool IsCycle1 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether cycle 2 is enabled.
    /// </summary>
    public bool IsCycle2 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether cycle 3 is enabled.
    /// </summary>
    public bool IsCycle3 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether oil is disabled.
    /// </summary>
    public bool IsOilOff { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether internal oil mode is enabled.
    /// </summary>
    public bool IsOilnt { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether oil is enabled.
    /// </summary>
    public bool IsOilOn { get; set; }
}
