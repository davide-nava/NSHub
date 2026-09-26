// <copyright file="Article.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an article stored in the system.
/// </summary>
public class Article : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the parent article identifier.
    /// </summary>
    public Guid? ParentArticleId { get; set; }

    /// <summary>
    /// Gets or sets the article brand identifier.
    /// </summary>
    public Guid? ArticleBrandId { get; set; }

    /// <summary>
    /// Gets or sets the article category identifier.
    /// </summary>
    public Guid? ArticleCategoryId { get; set; }

    /// <summary>
    /// Gets or sets the warehouse identifier.
    /// </summary>
    public Guid? WarehouseId { get; set; }

    /// <summary>
    /// Gets or sets the article type identifier.
    /// </summary>
    public Guid? ArticleTypeId { get; set; }

    /// <summary>
    /// Gets or sets the unit of measure identifier.
    /// </summary>
    public Guid UnitOfMeasureId { get; set; }

    /// <summary>
    /// Gets or sets the supplier identifier.
    /// </summary>
    public Guid? SupplierId { get; set; }

    /// <summary>
    /// Gets or sets the article description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the article number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the available quantity.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Gets or sets the image path or URL.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the article amount.
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Gets or sets the minimum stock quantity.
    /// </summary>
    public decimal? MinimumStock { get; set; }

    /// <summary>
    /// Gets or sets the purchase price.
    /// </summary>
    public decimal? PurchasePrice { get; set; }

    /// <summary>
    /// Gets or sets the sale price.
    /// </summary>
    public decimal? SalePrice { get; set; }

    /// <summary>
    /// Gets or sets the internal article code.
    /// </summary>
    public string? InternalArticleCode { get; set; }

    /// <summary>
    /// Gets or sets the supplier article code.
    /// </summary>
    public string? SupplierArticleCode { get; set; }

    /// <summary>
    /// Gets or sets the file system folder associated with the article.
    /// </summary>
    public string? FsFolder { get; set; }

    /// <summary>
    /// Gets or sets the website URL.
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the family code.
    /// </summary>
    public string? FamilyCode { get; set; }

    /// <summary>
    /// Gets or sets the barcode.
    /// </summary>
    public string? Barcode { get; set; }

    /// <summary>
    /// Gets or sets the storage location.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Gets or sets the related program.
    /// </summary>
    public string? Program { get; set; }

    /// <summary>
    /// Gets or sets the processing time.
    /// </summary>
    public string? ProcessingTime { get; set; }

    /// <summary>
    /// Gets or sets the searchable text.
    /// </summary>
    public string? Search { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether batch management is enabled.
    /// </summary>
    public bool IsBatchManaged { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether serial number management is enabled.
    /// </summary>
    public bool IsSerialNumberManaged { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the article is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the brand associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleBrand? ArticleBrand { get; set; }

    /// <summary>
    /// Gets or sets the category associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleCategory? ArticleCategory { get; set; }

    /// <summary>
    /// Gets or sets the type associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleType? ArticleType { get; set; }

    /// <summary>
    /// Gets or sets the parent article in a self-referencing hierarchy.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? ParentArticle { get; set; }

    /// <summary>
    /// Gets or sets the unit of measure associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual UnitOfMeasure? UnitOfMeasure { get; set; }

    /// <summary>
    /// Gets or sets the warehouse associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Warehouse? Warehouse { get; set; }

    /// <summary>
    /// Gets or sets the child articles associated with this article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> ChildArticles { get; set; } = [];
}
