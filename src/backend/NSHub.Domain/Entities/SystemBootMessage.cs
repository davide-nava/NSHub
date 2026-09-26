// <copyright file="SystemBootMessage.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a system boot message.
/// </summary>
public class SystemBootMessage : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the boot message code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the boot message description.
    /// </summary>
    public string Description { get; set; } = string.Empty;
}
