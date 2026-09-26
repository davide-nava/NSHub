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
    /// Gets the parent article identifier.
    /// </summary>
    public Guid? ParentArticleId { get; protected set; }

    /// <summary>
    /// Gets the article brand identifier.
    /// </summary>
    public Guid? ArticleBrandId { get; protected set; }

    /// <summary>
    /// Gets the article category identifier.
    /// </summary>
    public Guid? ArticleCategoryId { get; protected set; }

    /// <summary>
    /// Gets the warehouse identifier.
    /// </summary>
    public Guid? WarehouseId { get; protected set; }

    /// <summary>
    /// Gets the article type identifier.
    /// </summary>
    public Guid? ArticleTypeId { get; protected set; }

    /// <summary>
    /// Gets the unit of measure identifier.
    /// </summary>
    public Guid UnitOfMeasureId { get; protected set; }

    /// <summary>
    /// Gets the supplier identifier.
    /// </summary>
    public Guid? SupplierId { get; protected set; }

    /// <summary>
    /// Gets the article description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the article number.
    /// </summary>
    public string Number { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the available quantity.
    /// </summary>
    public decimal Quantity { get; protected set; }

    /// <summary>
    /// Gets the image path or URL.
    /// </summary>
    public string Image { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the article amount.
    /// </summary>
    public decimal? Amount { get; protected set; }

    /// <summary>
    /// Gets the minimum stock quantity.
    /// </summary>
    public decimal? MinimumStock { get; protected set; }

    /// <summary>
    /// Gets the purchase price.
    /// </summary>
    public decimal? PurchasePrice { get; protected set; }

    /// <summary>
    /// Gets the sale price.
    /// </summary>
    public decimal? SalePrice { get; protected set; }

    /// <summary>
    /// Gets the internal article code.
    /// </summary>
    public string? InternalArticleCode { get; protected set; }

    /// <summary>
    /// Gets the supplier article code.
    /// </summary>
    public string? SupplierArticleCode { get; protected set; }

    /// <summary>
    /// Gets the file system folder associated with the article.
    /// </summary>
    public string? FsFolder { get; protected set; }

    /// <summary>
    /// Gets the website URL.
    /// </summary>
    public string? Website { get; protected set; }

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the family code.
    /// </summary>
    public string? FamilyCode { get; protected set; }

    /// <summary>
    /// Gets the barcode.
    /// </summary>
    public string? Barcode { get; protected set; }

    /// <summary>
    /// Gets the storage location.
    /// </summary>
    public string? Location { get; protected set; }

    /// <summary>
    /// Gets the related program.
    /// </summary>
    public string? Program { get; protected set; }

    /// <summary>
    /// Gets the processing time.
    /// </summary>
    public string? ProcessingTime { get; protected set; }

    /// <summary>
    /// Gets the searchable text.
    /// </summary>
    public string? Search { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether batch management is enabled.
    /// </summary>
    public bool IsBatchManaged { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether serial number management is enabled.
    /// </summary>
    public bool IsSerialNumberManaged { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the article is active.
    /// </summary>
    public bool IsActive { get; protected set; }

    /// <summary>
    /// Gets the brand associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleBrand? ArticleBrand { get; protected set; }

    /// <summary>
    /// Gets the category associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleCategory? ArticleCategory { get; protected set; }

    /// <summary>
    /// Gets the type associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleType? ArticleType { get; protected set; }

    /// <summary>
    /// Gets the parent article in a self-referencing hierarchy.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? ParentArticle { get; protected set; }

    /// <summary>
    /// Gets the unit of measure associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual UnitOfMeasure? UnitOfMeasure { get; protected set; }

    /// <summary>
    /// Gets the warehouse associated with the article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Warehouse? Warehouse { get; protected set; }

    /// <summary>
    /// Gets the child articles associated with this article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> ChildArticles { get; protected set; } = [];

}
