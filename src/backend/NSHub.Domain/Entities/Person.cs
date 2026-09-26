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
    /// Gets the first name.
    /// </summary>
    public string FirstName { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the last name.
    /// </summary>
    public string LastName { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the gender.
    /// </summary>
    public string? Gender { get; protected set; }

    /// <summary>
    /// Gets the birth date.
    /// </summary>
    public DateTime? BirthDate { get; protected set; }

    /// <summary>
    /// Gets the place of birth.
    /// </summary>
    public string? BirthPlace { get; protected set; }

    /// <summary>
    /// Gets the birth country code.
    /// </summary>
    public string? BirthCountryCode { get; protected set; }

    /// <summary>
    /// Gets the civil status.
    /// </summary>
    public string? CivilStatus { get; protected set; }

    /// <summary>
    /// Gets the associated party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? Party { get; protected set; }

    /// <summary>
    /// Gets the warehouses associated with this person.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Warehouse> Warehouses { get; protected set; }
        = new List<Warehouse>();
}
