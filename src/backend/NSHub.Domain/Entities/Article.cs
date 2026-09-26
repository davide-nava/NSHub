// <copyright file="Article.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Article : AuditableTenantEntity
{
    public Guid? ParentArticleId { get; protected set; }
    public Guid? ArticleBrandId { get; protected set; }
    public Guid? ArticleCategoryId { get; protected set; }
    public Guid? WarehouseId { get; protected set; }
    public Guid? ArticleTypeId { get; protected set; }
    public Guid UnitOfMeasureId { get; protected set; }
    public Guid? SupplierId { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public string Number { get; protected set; } = string.Empty;
    public decimal Quantity { get; protected set; }
    public string Image { get; protected set; } = string.Empty;
    public decimal? Amount { get; protected set; }
    public decimal? MinimumStock { get; protected set; }
    public decimal? PurchasePrice { get; protected set; }
    public decimal? SalePrice { get; protected set; }
    public string? InternalArticleCode { get; protected set; }
    public string? SupplierArticleCode { get; protected set; }
    public string? FsFolder { get; protected set; }
    public string? Website { get; protected set; }
    public string? Notes { get; protected set; }
    public string? FamilyCode { get; protected set; }
    public string? Barcode { get; protected set; }
    public string? Location { get; protected set; }
    public string? Program { get; protected set; }
    public string? ProcessingTime { get; protected set; }
    public string? Search { get; protected set; }
    public bool IsBatchManaged { get; protected set; }
    public bool IsSerialNumberManaged { get; protected set; }
    public bool IsActive { get; protected set; }
    public virtual ArticleBrand? ArticleBrand { get; protected set; }
    public virtual ArticleCategory? ArticleCategory { get; protected set; }
    public virtual ArticleType? ArticleType { get; protected set; }
    public virtual Article? ParentArticle { get; protected set; }
    public virtual UnitOfMeasure? UnitOfMeasure { get; protected set; }
    public virtual Warehouse? Warehouse { get; protected set; }

    private readonly List<Article> _childArticles = new();
    public virtual IReadOnlyCollection<Article> ChildArticles => _childArticles.AsReadOnly();
    private readonly List<ArticleCategoryMap> _articleCategoryMaps = new();
    public virtual IReadOnlyCollection<ArticleCategoryMap> ArticleCategoryMaps => _articleCategoryMaps.AsReadOnly();
    private readonly List<ArticleGroupMap> _articleGroupMaps = new();
    public virtual IReadOnlyCollection<ArticleGroupMap> ArticleGroupMaps => _articleGroupMaps.AsReadOnly();
    private readonly List<ArticleMachine> _articleMachines = new();
    public virtual IReadOnlyCollection<ArticleMachine> ArticleMachines => _articleMachines.AsReadOnly();
    private readonly List<DeliveryNoteRow> _deliveryNoteRows = new();
    public virtual IReadOnlyCollection<DeliveryNoteRow> DeliveryNoteRows => _deliveryNoteRows.AsReadOnly();
    private readonly List<InvoiceRow> _invoiceRows = new();
    public virtual IReadOnlyCollection<InvoiceRow> InvoiceRows => _invoiceRows.AsReadOnly();
    private readonly List<OrderRow> _orderRows = new();
    public virtual IReadOnlyCollection<OrderRow> OrderRows => _orderRows.AsReadOnly();
    private readonly List<PriceListItem> _priceListItems = new();
    public virtual IReadOnlyCollection<PriceListItem> PriceListItems => _priceListItems.AsReadOnly();
    private readonly List<QuotationRow> _quotationRows = new();
    public virtual IReadOnlyCollection<QuotationRow> QuotationRows => _quotationRows.AsReadOnly();
    private readonly List<ShipmentArticle> _shipmentArticles = new();
    public virtual IReadOnlyCollection<ShipmentArticle> ShipmentArticles => _shipmentArticles.AsReadOnly();
    private readonly List<StockMovement> _stockMovements = new();
    public virtual IReadOnlyCollection<StockMovement> StockMovements => _stockMovements.AsReadOnly();

    protected Article() { }

    public static Article Create(
        string number,
        string description,
        decimal quantity,
        string image,
        Guid unitOfMeasureId,
        decimal? purchasePrice = null,
        decimal? salePrice = null,
        Guid? supplierId = null,
        Guid? warehouseId = null)
    {
        return new Article
        {
            Number = number,
            Description = description,
            Quantity = quantity,
            Image = image,
            UnitOfMeasureId = unitOfMeasureId,
            PurchasePrice = purchasePrice,
            SalePrice = salePrice,
            SupplierId = supplierId,
            WarehouseId = warehouseId,
            IsActive = true
        };
    }

    public void UpdatePricing(decimal? purchasePrice, decimal? salePrice)
    {
        PurchasePrice = purchasePrice;
        SalePrice = salePrice;
    }

    public void UpdateStock(decimal quantity)
    {
        Quantity = quantity;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
