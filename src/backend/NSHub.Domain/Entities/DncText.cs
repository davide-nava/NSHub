// <copyright file="DncText.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a DNC text message.
/// </summary>
public class DncText : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the language identifier.
    /// </summary>
    public Guid LanguageId { get; set; }

    /// <summary>
    /// Gets or sets the DNC text number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the DNC text content.
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the associated language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Language? Language { get; set; }
}
