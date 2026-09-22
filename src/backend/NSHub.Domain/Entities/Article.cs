// <copyright file="Article.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Enums;

namespace NSHub.Domain.Entities;

/// <summary>
/// Aggregate root representing an inventory article or product.
/// </summary>
public class Article : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique SKU or article code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the article.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the primary unit of measure.
    /// </summary>
    public ArticleUnitOfMeasure UnitOfMeasure { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the article is active for sales and stock.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>Gets or sets the amount/price.</summary>
    public decimal? Amount { get; set; }

    /// <summary>Gets or sets the quantity.</summary>
    public decimal? Quantity { get; set; }

    /// <summary>Gets or sets the photo binary data.</summary>
    public IEnumerable<byte>? Photo { get; set; }

    /// <summary>Gets or sets the unit of measure code.</summary>
    public int? CodUdm { get; set; }

    /// <summary>Gets or sets the brand code.</summary>
    public int? CodBrand { get; set; }

    /// <summary>Gets or sets the category code.</summary>
    public int? CodCategory { get; set; }

    /// <summary>Gets or sets the minimum stock threshold.</summary>
    public decimal? MinimumStock { get; set; }

    /// <summary>Gets or sets the purchase price.</summary>
    public decimal? PurchasePrice { get; set; }

    /// <summary>Gets or sets the internal article code.</summary>
    public string? InternalArticleCode { get; set; }

    /// <summary>Gets or sets the supplier article code.</summary>
    public string? SupplierArticleCode { get; set; }

    /// <summary>Gets or sets the warehouse code.</summary>
    public int? CodWarehouse { get; set; }

    /// <summary>Gets or sets the article type code.</summary>
    public int? CodArticleType { get; set; }

    /// <summary>Gets or sets the filesystem folder path.</summary>
    public string? FileSystemFolder { get; set; }

    /// <summary>Gets or sets the website link or path.</summary>
    public string? Website { get; set; }

    /// <summary>Gets or sets additional notes.</summary>
    public string? Notes { get; set; }

    /// <summary>Gets or sets the family code.</summary>
    public string? CodFamily { get; set; }

    /// <summary>Gets or sets the barcode.</summary>
    public string? Barcode { get; set; }

    /// <summary>Gets or sets the physical location.</summary>
    public string? Location { get; set; }

    /// <summary>Gets or sets the program details.</summary>
    public string? Program { get; set; }

    /// <summary>Gets or sets the processing time.</summary>
    public string? ProcessingTime { get; set; }
}
