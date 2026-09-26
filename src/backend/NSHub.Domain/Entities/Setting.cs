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
    /// Gets the unique setting key.
    /// </summary>
    public string Key { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the setting value.
    /// </summary>
    public string? Value { get; protected set; }

    /// <summary>
    /// Gets the setting group.
    /// </summary>
    public string Group { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the setting description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;
}
