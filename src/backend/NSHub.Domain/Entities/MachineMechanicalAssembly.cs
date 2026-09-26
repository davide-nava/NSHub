// <copyright file="MachineMechanicalAssembly.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a machine mechanical assembly.
/// </summary>
public class MachineMechanicalAssembly : AuditableTenantEntity
{
    /// <summary>
    /// Gets the assembly reference.
    /// </summary>
    public string Ref { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the assembly code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;
}
