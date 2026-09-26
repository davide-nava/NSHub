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
    /// Gets or sets the NCK configuration.
    /// </summary>
    public string Config { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current NCK state.
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the affair information.
    /// </summary>
    public string Affair { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the extended NCK state.
    /// </summary>
    public string StateEnh { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the function block name.
    /// </summary>
    public string FbName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the NCK software version.
    /// </summary>
    public string Version { get; set; } = string.Empty;
}
