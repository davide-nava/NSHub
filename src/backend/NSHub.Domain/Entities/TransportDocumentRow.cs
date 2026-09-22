// <copyright file="TransportDocumentRow.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a line item in a Transport Document (DDT).
/// </summary>
public class TransportDocumentRow
{
    /// <summary>Gets or sets the row code (composite key).</summary>
    public int CodDdtRow { get; set; }

    /// <summary>Gets or sets the year (composite key).</summary>
    public int Year { get; set; }

    /// <summary>Gets or sets the document code (composite key).</summary>
    public int CodDdt { get; set; }

    /// <summary>Gets or sets the article code.</summary>
    public string? CodArticle { get; set; }

    /// <summary>Gets or sets the quantity.</summary>
    public decimal? Quantity { get; set; }

    /// <summary>Gets or sets the description.</summary>
    public string? Description { get; set; }

    /// <summary>Gets or sets the unit of measure code.</summary>
    public string CodUdm { get; set; } = null!;

    /// <summary>Gets or sets the row sequence number.</summary>
    public decimal? RowNumber { get; set; }
}
