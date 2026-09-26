// <copyright file="PlcVariable.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a PLC variable.
/// </summary>
public class PlcVariable : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the PLC variable type identifier.
    /// </summary>
    public Guid PlcVariableTypeId { get; set; }

    /// <summary>
    /// Gets or sets the PLC variable group type identifier.
    /// </summary>
    public Guid PlcVariableGroupTypeId { get; set; }

    /// <summary>
    /// Gets or sets the variable name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the icon displayed when the variable is active.
    /// </summary>
    public string? IconOn { get; set; }

    /// <summary>
    /// Gets or sets the image associated with the variable.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the icon displayed when the variable is inactive.
    /// </summary>
    public string? IconOff { get; set; }

    /// <summary>
    /// Gets or sets the variable description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the insertion date.
    /// </summary>
    public DateTime InsertionDate { get; set; }

    /// <summary>
    /// Gets or sets the access rights associated with the variable.
    /// </summary>
    public string? AccessRights { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the variable supports write operations.
    /// </summary>
    public bool IsWriting { get; set; }

    /// <summary>
    /// Gets or sets the additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the variable values are historized.
    /// </summary>
    public bool IsHistorize { get; set; }

    /// <summary>
    /// Gets or sets the display order.
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Gets or sets the machine number associated with the variable.
    /// </summary>
    public string? MachineNumber { get; set; }

    /// <summary>
    /// Gets or sets the PLC variable group type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PlcVariableGroupType? PlcVariableGroupType { get; set; }

    /// <summary>
    /// Gets or sets the PLC variable type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PlcVariableType? PlcVariableType { get; set; }
}
