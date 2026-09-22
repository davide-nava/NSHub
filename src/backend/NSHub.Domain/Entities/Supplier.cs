// <copyright file="Supplier.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a supplier entity.
/// </summary>
public class Supplier
{
    /// <summary>Gets or sets the supplier code (Primary Key, Identity).</summary>
    public int CodSupplier { get; set; }

    /// <summary>Gets or sets the supplier denomination/name.</summary>
    public string? Denomination { get; set; }

    /// <summary>Gets or sets the VAT number.</summary>
    public string? VatNumber { get; set; }

    /// <summary>Gets or sets the address.</summary>
    public string? Address { get; set; }

    /// <summary>Gets or sets the postal code.</summary>
    public string? PostalCode { get; set; }

    /// <summary>Gets or sets the city.</summary>
    public string? City { get; set; }

    /// <summary>Gets or sets the province.</summary>
    public string? Province { get; set; }

    /// <summary>Gets or sets the phone number.</summary>
    public string? Phone { get; set; }

    /// <summary>Gets or sets the fax number.</summary>
    public string? Fax { get; set; }

    /// <summary>Gets or sets the website.</summary>
    public string? Website { get; set; }

    /// <summary>Gets or sets the email address.</summary>
    public string? Email { get; set; }

    /// <summary>Gets or sets the insertion date.</summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>Gets or sets the photo.</summary>
    public IEnumerable<byte>? Photo { get; set; }

    /// <summary>Gets or sets the mobile phone number.</summary>
    public string? MobilePhone { get; set; }

    /// <summary>Gets or sets the ABI bank code.</summary>
    public string? Abi { get; set; }

    /// <summary>Gets or sets the CAB bank code.</summary>
    public string? Cab { get; set; }

    /// <summary>Gets or sets the IBAN.</summary>
    public string? Iban { get; set; }

    /// <summary>Gets or sets the country.</summary>
    public string? Country { get; set; }

    /// <summary>Gets or sets notes.</summary>
    public string? Notes { get; set; }

    /// <summary>Gets or sets miscellaneous details.</summary>
    public string? Miscellaneous { get; set; }

    /// <summary>Gets or sets who introduced this supplier.</summary>
    public string? IntroducedBy { get; set; }
}
