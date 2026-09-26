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
    /// Gets the PLC variable identifier.
    /// </summary>
    public Guid PlcVariableId { get; protected set; }

    /// <summary>
    /// Gets the variable name.
    /// </summary>
    public string? Name { get; protected set; }

    /// <summary>
    /// Gets the variable value.
    /// </summary>
    public string? Value { get; protected set; }

    /// <summary>
    /// Gets the machine number.
    /// </summary>
    public string? MachineNumber { get; protected set; }

    /// <summary>
    /// Gets the acquisition date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the associated program.
    /// </summary>
    public string? Program { get; protected set; }

    /// <summary>
    /// Gets the associated PLC variable.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PlcVariable? PlcVariable { get; protected set; }
}
