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
    /// Gets the X coordinate.
    /// </summary>
    public decimal X { get; protected set; }

    /// <summary>
    /// Gets the Y coordinate.
    /// </summary>
    public decimal Y { get; protected set; }

    /// <summary>
    /// Gets the Z coordinate.
    /// </summary>
    public decimal Z { get; protected set; }

    /// <summary>
    /// Gets the V coordinate.
    /// </summary>
    public decimal V { get; protected set; }

    /// <summary>
    /// Gets the W coordinate.
    /// </summary>
    public decimal W { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether position 1 is enabled.
    /// </summary>
    public bool IsPos1 { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether position 2 is enabled.
    /// </summary>
    public bool IsPos2 { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether position 3 is enabled.
    /// </summary>
    public bool IsPos3 { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether cycle 1 is enabled.
    /// </summary>
    public bool IsCycle1 { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether cycle 2 is enabled.
    /// </summary>
    public bool IsCycle2 { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether cycle 3 is enabled.
    /// </summary>
    public bool IsCycle3 { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether oil is disabled.
    /// </summary>
    public bool IsOilOff { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether internal oil mode is enabled.
    /// </summary>
    public bool IsOilnt { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether oil is enabled.
    /// </summary>
    public bool IsOilOn { get; protected set; }
}
