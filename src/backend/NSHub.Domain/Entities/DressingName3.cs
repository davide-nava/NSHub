// <copyright file="DressingName3.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the localized labels and descriptions used for dressing configuration 3.
/// </summary>
public class DressingName3 : AuditableTenantEntity
{
    /// <summary>
    /// Gets the language identifier.
    /// </summary>
    public Guid LanguageId { get; protected set; }

    /// <summary>
    /// Gets the localized label for the work spindle.
    /// </summary>
    public string WorkSpiende { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the optional high-frequency spindle.
    /// </summary>
    public string OptHfSpindle { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the optional normal spindle.
    /// </summary>
    public string OptNormSpendle { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the wheel direction.
    /// </summary>
    public string Direction { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the high-frequency spindle.
    /// </summary>
    public string Hf { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the wheel hand.
    /// </summary>
    public string WheelHand { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the associated language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Language? Language { get; protected set; }
}
