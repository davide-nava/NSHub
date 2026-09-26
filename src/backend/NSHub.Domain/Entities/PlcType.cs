// <copyright file="PlcType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a PLC type.
/// </summary>
public class PlcType : AuditableTenantEntity
{
    /// <summary>
    /// Gets the PLC type description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the PLC type code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;
}
