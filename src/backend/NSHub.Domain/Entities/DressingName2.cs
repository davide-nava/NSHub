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
    /// Gets the language identifier.
    /// </summary>
    public Guid LanguageId { get; protected set; }

    /// <summary>
    /// Gets the localized label for the retreat parameter.
    /// </summary>
    public string Retreat { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the chip parameter.
    /// </summary>
    public string Chip { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the ANCL parameter.
    /// </summary>
    public string Ancl { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the internal allowance parameter.
    /// </summary>
    public string AllInt { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the external allowance parameter.
    /// </summary>
    public string AllExt { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the output velocity parameter.
    /// </summary>
    public string OutVel { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the velocity parameter.
    /// </summary>
    public string Vel { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for the removal parameter.
    /// </summary>
    public string Removal { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for cycle 2.
    /// </summary>
    public string Cycle2 { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the localized label for cycle 3.
    /// </summary>
    public string Cycle3 { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the associated language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Language? Language { get; protected set; }
}
