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
    /// Gets or sets the retraction value.
    /// </summary>
    public decimal Retraction { get; set; }

    /// <summary>
    /// Gets or sets the chip value for cycle 1.
    /// </summary>
    public decimal Chip { get; set; }

    /// <summary>
    /// Gets or sets the chip value for cycle 2.
    /// </summary>
    public decimal Chip2 { get; set; }

    /// <summary>
    /// Gets or sets the chip value for cycle 3.
    /// </summary>
    public decimal Chip3 { get; set; }

    /// <summary>
    /// Gets or sets the ANCL parameter.
    /// </summary>
    public decimal Ancl { get; set; }

    /// <summary>
    /// Gets or sets the internal allowance value.
    /// </summary>
    public decimal AllInt { get; set; }

    /// <summary>
    /// Gets or sets the external allowance value.
    /// </summary>
    public decimal AllExt { get; set; }

    /// <summary>
    /// Gets or sets the working advance value.
    /// </summary>
    public decimal WorkAdv { get; set; }

    /// <summary>
    /// Gets or sets the external axis velocity for cycle 1.
    /// </summary>
    public decimal ExtAxVel { get; set; }

    /// <summary>
    /// Gets or sets the external axis velocity for cycle 2.
    /// </summary>
    public decimal ExtAxVel2 { get; set; }

    /// <summary>
    /// Gets or sets the external axis velocity for cycle 3.
    /// </summary>
    public decimal ExtAxVel3 { get; set; }

    /// <summary>
    /// Gets or sets the material removal value for cycle 1.
    /// </summary>
    public decimal Removal { get; set; }

    /// <summary>
    /// Gets or sets the material removal value for cycle 2.
    /// </summary>
    public decimal Removal2 { get; set; }

    /// <summary>
    /// Gets or sets the material removal value for cycle 3.
    /// </summary>
    public decimal Removal3 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether cycle 2 is enabled.
    /// </summary>
    public bool IsCycle2 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether cycle 3 is enabled.
    /// </summary>
    public bool IsCycle3 { get; set; }
}
