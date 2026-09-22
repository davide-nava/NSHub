// <copyright file="TransportDocument.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a Transport Document (DDT) entity.
/// </summary>
public class TransportDocument
{
    /// <summary>Gets or sets the document code part of composite key.</summary>
    public int CodDdt { get; set; }

    /// <summary>Gets or sets the year part of composite key.</summary>
    public int Year { get; set; }

    /// <summary>Gets or sets the document date.</summary>
    public DateTime? Date { get; set; }

    /// <summary>Gets or sets the billing customer code.</summary>
    public int? CodCustomerBilling { get; set; }

    /// <summary>Gets or sets the goods recipient customer code.</summary>
    public int? CodCustomerGoods { get; set; }

    /// <summary>Gets or sets the transport reason code.</summary>
    public string CodTransportReason { get; set; } = null!;

    /// <summary>Gets or sets the outer appearance of goods code.</summary>
    public string? CodGoodsAppearance { get; set; }

    /// <summary>Gets or sets the transport care code.</summary>
    public string? CodTransportCare { get; set; }

    /// <summary>Gets or sets the carriage/port code.</summary>
    public string? CodPort { get; set; }

    /// <summary>Gets or sets notes.</summary>
    public string? Notes { get; set; }

    /// <summary>Gets or sets the number of packages.</summary>
    public decimal? NumberOfPackages { get; set; }

    /// <summary>Gets or sets the total weight.</summary>
    public decimal? Weight { get; set; }

    /// <summary>Gets or sets the insertion date.</summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>Gets or sets the carriers info.</summary>
    public string? Carriers { get; set; }

    /// <summary>Gets or sets a value indicating whether the document is closed.</summary>
    public bool? IsClosed { get; set; }

    /// <summary>Gets or sets our reference info.</summary>
    public string? OurReference { get; set; }

    /// <summary>Gets or sets the order reference info.</summary>
    public string? OrderReference { get; set; }

    /// <summary>Gets or sets their reference info.</summary>
    public string? TheirReference { get; set; }
}
