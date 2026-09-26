// <copyright file="PlcVariableGroupType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a PLC variable group type.
/// </summary>
public class PlcVariableGroupType : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the group type description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the PLC variables associated with this group type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PlcVariable> PlcVariables { get; set; }
        = [];
}
