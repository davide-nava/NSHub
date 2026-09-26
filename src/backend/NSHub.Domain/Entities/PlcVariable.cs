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
    /// Gets the PLC variable type identifier.
    /// </summary>
    public Guid PlcVariableTypeId { get; protected set; }

    /// <summary>
    /// Gets the PLC variable group type identifier.
    /// </summary>
    public Guid PlcVariableGroupTypeId { get; protected set; }

    /// <summary>
    /// Gets the variable name.
    /// </summary>
    public string Name { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the icon displayed when the variable is active.
    /// </summary>
    public string? IconOn { get; protected set; }

    /// <summary>
    /// Gets the image associated with the variable.
    /// </summary>
    public string? Image { get; protected set; }

    /// <summary>
    /// Gets the icon displayed when the variable is inactive.
    /// </summary>
    public string? IconOff { get; protected set; }

    /// <summary>
    /// Gets the variable description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the insertion date.
    /// </summary>
    public DateTime InsertionDate { get; protected set; }

    /// <summary>
    /// Gets the access rights associated with the variable.
    /// </summary>
    public string? AccessRights { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the variable supports write operations.
    /// </summary>
    public bool IsWriting { get; protected set; }

    /// <summary>
    /// Gets the additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the variable values are historized.
    /// </summary>
    public bool IsHistorize { get; protected set; }

    /// <summary>
    /// Gets the display order.
    /// </summary>
    public int Order { get; protected set; }

    /// <summary>
    /// Gets the machine number associated with the variable.
    /// </summary>
    public string? MachineNumber { get; protected set; }

    /// <summary>
    /// Gets the PLC variable group type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PlcVariableGroupType? PlcVariableGroupType { get; protected set; }

    /// <summary>
    /// Gets the PLC variable type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PlcVariableType? PlcVariableType { get; protected set; }
}
