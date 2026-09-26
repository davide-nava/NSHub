// <copyright file="InvoiceRow.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class InvoiceRow : AuditableTenantEntity
{
    public int Year { get; protected set; }
    public Guid InvoiceId { get; protected set; }
    public Guid? ArticleId { get; protected set; }
    public string? ArticleCode { get; protected set; }
    public decimal? Quantity { get; protected set; }
    public decimal UnitPrice { get; protected set; }
    public decimal DiscountPercentage { get; protected set; }
    public decimal? Amount { get; protected set; }
    public Guid? VatId { get; protected set; }
    public decimal LineTotal { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public decimal? RowNumber { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual Invoice? Invoice { get; protected set; }
    public virtual Vat? Vat { get; protected set; }

    protected InvoiceRow() { }

    public static InvoiceRow Create()
    {
        return new InvoiceRow();
    }
}
