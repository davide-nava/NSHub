// <copyright file="Warehouse.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a warehouse entity.
/// </summary>
public class Warehouse : BaseEntity
{
    /// <summary>Gets or sets the warehouse code (Primary Key, Identity).</summary>
    public int CodWarehouse { get; set; }

    /// <summary>Gets or sets the phone number.</summary>
    public string? Phone { get; set; }

    /// <summary>Gets or sets the fax number.</summary>
    public string? Fax { get; set; }

    /// <summary>Gets or sets the address.</summary>
    public string? Address { get; set; }

    /// <summary>Gets or sets the postal code.</summary>
    public string? PostalCode { get; set; }

    /// <summary>Gets or sets the province.</summary>
    public string? Province { get; set; }

    /// <summary>Gets or sets the city.</summary>
    public string? City { get; set; }

    /// <summary>Gets or sets the state/region.</summary>
    public string? State { get; set; }

    /// <summary>Gets or sets the person in charge.</summary>
    public string? Manager { get; set; }

    /// <summary>Gets or sets the description.</summary>
    public string? Description { get; set; }

    /// <summary>Gets or sets a value indicating whether it is an external warehouse.</summary>
    public bool? IsExternal { get; set; }

    /// <summary>Gets or sets the opening time.</summary>
    public string? OpeningTime { get; set; }

    /// <summary>Gets or sets the closing time.</summary>
    public string? ClosingTime { get; set; }

    /// <summary>Gets or sets the email address.</summary>
    public string? Email { get; set; }

    /// <summary>Gets or sets the name/denomination.</summary>
    public string? Denomination { get; set; }
}
