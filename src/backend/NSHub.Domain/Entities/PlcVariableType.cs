// <copyright file="PlcVariableType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a PLC variable type.
/// </summary>
public class PlcVariableType : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the variable type description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the PLC variables associated with this type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PlcVariable> PlcVariables { get; set; }
        = [];
}
