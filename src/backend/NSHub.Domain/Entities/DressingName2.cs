// <copyright file="DressingName2.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the localized labels and descriptions used for dressing configuration 2.
/// </summary>
public class DressingName2 : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the language identifier.
    /// </summary>
    public Guid LanguageId { get; set; }

    /// <summary>
    /// Gets or sets the localized label for the retreat parameter.
    /// </summary>
    public string Retreat { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for the chip parameter.
    /// </summary>
    public string Chip { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for the ANCL parameter.
    /// </summary>
    public string Ancl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for the internal allowance parameter.
    /// </summary>
    public string AllInt { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for the external allowance parameter.
    /// </summary>
    public string AllExt { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for the output velocity parameter.
    /// </summary>
    public string OutVel { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for the velocity parameter.
    /// </summary>
    public string Vel { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for the removal parameter.
    /// </summary>
    public string Removal { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for cycle 2.
    /// </summary>
    public string Cycle2 { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the localized label for cycle 3.
    /// </summary>
    public string Cycle3 { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the associated language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Language? Language { get; set; }
}
