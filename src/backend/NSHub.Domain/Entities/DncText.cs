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
    /// Gets the language identifier.
    /// </summary>
    public Guid LanguageId { get; protected set; }

    /// <summary>
    /// Gets the DNC text number.
    /// </summary>
    public string Number { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the DNC text content.
    /// </summary>
    public string Text { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the associated language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Language? Language { get; protected set; }
}
