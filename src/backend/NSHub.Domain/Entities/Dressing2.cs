// <copyright file="Dressing2.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a dressing configuration.
/// </summary>
public class Dressing2 : AuditableTenantEntity
{
    /// <summary>
    /// Gets the retraction value.
    /// </summary>
    public decimal Retraction { get; protected set; }

    /// <summary>
    /// Gets the chip value for cycle 1.
    /// </summary>
    public decimal Chip { get; protected set; }

    /// <summary>
    /// Gets the chip value for cycle 2.
    /// </summary>
    public decimal Chip2 { get; protected set; }

    /// <summary>
    /// Gets the chip value for cycle 3.
    /// </summary>
    public decimal Chip3 { get; protected set; }

    /// <summary>
    /// Gets the ANCL parameter.
    /// </summary>
    public decimal Ancl { get; protected set; }

    /// <summary>
    /// Gets the internal allowance value.
    /// </summary>
    public decimal AllInt { get; protected set; }

    /// <summary>
    /// Gets the external allowance value.
    /// </summary>
    public decimal AllExt { get; protected set; }

    /// <summary>
    /// Gets the working advance value.
    /// </summary>
    public decimal WorkAdv { get; protected set; }

    /// <summary>
    /// Gets the external axis velocity for cycle 1.
    /// </summary>
    public decimal ExtAxVel { get; protected set; }

    /// <summary>
    /// Gets the external axis velocity for cycle 2.
    /// </summary>
    public decimal ExtAxVel2 { get; protected set; }

    /// <summary>
    /// Gets the external axis velocity for cycle 3.
    /// </summary>
    public decimal ExtAxVel3 { get; protected set; }

    /// <summary>
    /// Gets the material removal value for cycle 1.
    /// </summary>
    public decimal Removal { get; protected set; }

    /// <summary>
    /// Gets the material removal value for cycle 2.
    /// </summary>
    public decimal Removal2 { get; protected set; }

    /// <summary>
    /// Gets the material removal value for cycle 3.
    /// </summary>
    public decimal Removal3 { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether cycle 2 is enabled.
    /// </summary>
    public bool IsCycle2 { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether cycle 3 is enabled.
    /// </summary>
    public bool IsCycle3 { get; protected set; }
}
