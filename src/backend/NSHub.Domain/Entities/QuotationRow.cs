// <copyright file="QuotationRow.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class QuotationRow : AuditableTenantEntity
{
    public int Year { get; protected set; }
    public Guid QuotationId { get; protected set; }
    public Guid? ArticleId { get; protected set; }
    public string? ArticleCode { get; protected set; }
    public decimal? Quantity { get; protected set; }
    public decimal UnitPrice { get; protected set; }
    public decimal DiscountPercentage { get; protected set; }
    public decimal? Amount { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public DateTime? InsertionDate { get; protected set; }
    public bool IsSale { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual Quotation? Quotation { get; protected set; }

    protected QuotationRow() { }

    public static QuotationRow Create()
    {
        return new QuotationRow();
    }
}
