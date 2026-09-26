// <copyright file="Nck.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an NCK (Numerical Control Kernel) instance.
/// </summary>
public class Nck : AuditableTenantEntity
{
    /// <summary>
    /// Gets the NCK configuration.
    /// </summary>
    public string Config { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the current NCK state.
    /// </summary>
    public string State { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the affair information.
    /// </summary>
    public string Affair { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the extended NCK state.
    /// </summary>
    public string StateEnh { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the function block name.
    /// </summary>
    public string FbName { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the NCK software version.
    /// </summary>
    public string Version { get; protected set; } = string.Empty;
}
