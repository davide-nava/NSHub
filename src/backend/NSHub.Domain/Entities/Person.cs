// <copyright file="Person.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a person.
/// </summary>
public class Person : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the gender.
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// Gets or sets the birth date.
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the place of birth.
    /// </summary>
    public string? BirthPlace { get; set; }

    /// <summary>
    /// Gets or sets the birth country code.
    /// </summary>
    public string? BirthCountryCode { get; set; }

    /// <summary>
    /// Gets or sets the civil status.
    /// </summary>
    public string? CivilStatus { get; set; }

    /// <summary>
    /// Gets or sets the associated party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? Party { get; set; }

    /// <summary>
    /// Gets or sets the warehouses associated with this person.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Warehouse> Warehouses { get; set; }
        = [];
}
