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
    /// Gets or sets the price list code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price list name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the currency code associated with the price list.
    /// </summary>
    public string CurrencyCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date from which the price list is valid.
    /// </summary>
    public DateTime ValidFrom { get; set; }

    /// <summary>
    /// Gets or sets the date until which the price list is valid.
    /// </summary>
    public DateTime? ValidTo { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the price list is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the price list items associated with this price list.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PriceListItem> PriceListItems { get; set; } = [];
}
