// <copyright file="MachineType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a machine type.
/// </summary>
public class MachineType : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the machine type number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the image path or URL.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the machine type description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the creation or registration date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the number of machine axes.
    /// </summary>
    public int Axes { get; set; }

    /// <summary>
    /// Gets or sets the number of spindles.
    /// </summary>
    public int Spindles { get; set; }

    /// <summary>
    /// Gets or sets the CNC type.
    /// </summary>
    public string? Cnc { get; set; }

    /// <summary>
    /// Gets or sets the machine specialty.
    /// </summary>
    public string? Specialty { get; set; }

    /// <summary>
    /// Gets or sets additional machine details.
    /// </summary>
    public string? Details { get; set; }

    /// <summary>
    /// Gets or sets the machines associated with this machine type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Machine> Machines { get; set; }
        = [];
}
