// <copyright file="Setting.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an application setting.
/// </summary>
public class Setting : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the unique setting key.
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the setting value.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Gets or sets the setting group.
    /// </summary>
    public string Group { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the setting description.
    /// </summary>
    public string Description { get; set; } = string.Empty;
}
