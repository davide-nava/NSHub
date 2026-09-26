// <copyright file="Person.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Person : BaseEntity
{
    public string FirstName { get; protected set; } = string.Empty;
    public string LastName { get; protected set; } = string.Empty;
    public string? Gender { get; protected set; }
    public DateTime? BirthDate { get; protected set; }
    public string? BirthPlace { get; protected set; }
    public string? BirthCountryCode { get; protected set; }
    public string? CivilStatus { get; protected set; }
    public virtual Party? Party { get; protected set; }

    private readonly List<Warehouse> _warehouses = new();
    public virtual IReadOnlyCollection<Warehouse> Warehouses => _warehouses.AsReadOnly();

    protected Person() { }

    public static Person Create()
    {
        return new Person();
    }
}
