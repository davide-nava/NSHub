// <copyright file="FxTextType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an FX text type.
/// </summary>
public class FxTextType : AuditableTenantEntity
{
    /// <summary>
    /// Gets the FX text type title.
    /// </summary>
    public string Title { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the FX text type description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;
}
