// <copyright file="MachineBuilder.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a machine builder.
/// </summary>
public class MachineBuilder : AuditableTenantEntity
{
    /// <summary>
    /// Gets the machine builder code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the machine builder description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;


}
