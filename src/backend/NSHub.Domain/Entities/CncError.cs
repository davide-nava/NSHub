// <copyright file="CncError.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a CNC machine error.
/// </summary>
public class CncError : AuditableTenantEntity
{
    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the error description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;
}
