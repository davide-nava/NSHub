// <copyright file="PriceList.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a price list.
/// </summary>
public class PriceList : AuditableTenantEntity
{
    /// <summary>
    /// Gets the price list code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the price list name.
    /// </summary>
    public string Name { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the currency code associated with the price list.
    /// </summary>
    public string CurrencyCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the date from which the price list is valid.
    /// </summary>
    public DateTime ValidFrom { get; protected set; }

    /// <summary>
    /// Gets the date until which the price list is valid.
    /// </summary>
    public DateTime? ValidTo { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the price list is active.
    /// </summary>
    public bool IsActive { get; protected set; }

    /// <summary>
    /// Gets the price list items associated with this price list.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PriceListItem> PriceListItems { get; protected set; }
        = new List<PriceListItem>();
}
