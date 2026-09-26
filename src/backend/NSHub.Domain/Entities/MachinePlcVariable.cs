// <copyright file="MachinePlcVariable.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a PLC variable value captured from a machine.
/// </summary>
public class MachinePlcVariable : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the PLC variable identifier.
    /// </summary>
    public Guid PlcVariableId { get; set; }

    /// <summary>
    /// Gets or sets the variable name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the variable value.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Gets or sets the machine number.
    /// </summary>
    public string? MachineNumber { get; set; }

    /// <summary>
    /// Gets or sets the acquisition date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the associated program.
    /// </summary>
    public string? Program { get; set; }

    /// <summary>
    /// Gets or sets the associated PLC variable.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PlcVariable? PlcVariable { get; set; }
}
