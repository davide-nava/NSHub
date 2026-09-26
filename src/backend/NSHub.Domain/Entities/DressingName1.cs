// <copyright file="DressingName1.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the localized labels and descriptions used for dressing configuration 1.
/// </summary>
public class DressingName1 : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the language identifier.
    /// </summary>
    public Guid LanguageId { get; set; }

    /// <summary>
    /// Gets or sets the localized label for position 1.
    /// </summary>
    public string Pos { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for position 2.
    /// </summary>
    public string Pos2 { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for position 3.
    /// </summary>
    public string Pos3 { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for cycle 1.
    /// </summary>
    public string Cycle1 { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for cycle 2.
    /// </summary>
    public string Cycle2 { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for cycle 3.
    /// </summary>
    public string Cycle3 { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for oil off mode.
    /// </summary>
    public string OilOff { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for internal oil mode.
    /// </summary>
    public string OilInt { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for oil on mode.
    /// </summary>
    public string OilOn { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the associated language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Language? Language { get; set; }
}
