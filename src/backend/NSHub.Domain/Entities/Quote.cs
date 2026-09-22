// <copyright file="Quote.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a quotation/estimate entity.
/// </summary>
public class Quote : BaseEntity
{
    /// <summary>Gets or sets the quote code (composite key).</summary>
    public int CodQuote { get; set; }

    /// <summary>Gets or sets the year (composite key).</summary>
    public int Year { get; set; }

    /// <summary>Gets or sets the quote date.</summary>
    public DateTime? Date { get; set; }

    /// <summary>Gets or sets the amount.</summary>
    public decimal? Amount { get; set; }

    /// <summary>Gets or sets the quantity.</summary>
    public decimal? Quantity { get; set; }

    /// <summary>Gets or sets the insertion date.</summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>Gets or sets notes.</summary>
    public string? Notes { get; set; }

    /// <summary>Gets or sets a value indicating whether the quote is closed.</summary>
    public bool? IsClosed { get; set; }

    /// <summary>Gets or sets the VAT code.</summary>
    public int? CodVat { get; set; }

    /// <summary>Gets or sets the payment method code (composite key).</summary>
    public int CodPayment { get; set; }

    /// <summary>Gets or sets a value indicating whether it's a sales quote (composite key).</summary>
    public bool IsSales { get; set; }

    /// <summary>Gets or sets our reference.</summary>
    public string? OurReference { get; set; }

    /// <summary>Gets or sets their reference.</summary>
    public string? TheirReference { get; set; }

    /// <summary>Gets or sets the customer code.</summary>
    public int? CodCustomer { get; set; }
}
