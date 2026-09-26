// <copyright file="PriceList.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class PriceList : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Name { get; protected set; } = string.Empty;
    public string CurrencyCode { get; protected set; } = string.Empty;
    public DateTime ValidFrom { get; protected set; }
    public DateTime? ValidTo { get; protected set; }
    public bool IsActive { get; protected set; }

    private readonly List<PriceListItem> _priceListItems = new();
    public virtual IReadOnlyCollection<PriceListItem> PriceListItems => _priceListItems.AsReadOnly();

    protected PriceList() { }

    public static PriceList Create()
    {
        return new PriceList();
    }
}
