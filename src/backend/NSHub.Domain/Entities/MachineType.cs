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
    /// Gets the machine type number.
    /// </summary>
    public string Number { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the image path or URL.
    /// </summary>
    public string? Image { get; protected set; }

    /// <summary>
    /// Gets the machine type description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the creation or registration date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the number of machine axes.
    /// </summary>
    public int Axes { get; protected set; }

    /// <summary>
    /// Gets the number of spindles.
    /// </summary>
    public int Spindles { get; protected set; }

    /// <summary>
    /// Gets the CNC type.
    /// </summary>
    public string? Cnc { get; protected set; }

    /// <summary>
    /// Gets the machine specialty.
    /// </summary>
    public string? Specialty { get; protected set; }

    /// <summary>
    /// Gets additional machine details.
    /// </summary>
    public string? Details { get; protected set; }

    /// <summary>
    /// Gets the machines associated with this machine type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Machine> Machines { get; protected set; }
        = new List<Machine>();
}
