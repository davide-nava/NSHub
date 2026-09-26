// <copyright file="Organization.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an organization.
/// </summary>
public class Organization : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the legal name.
    /// </summary>
    public string LegalName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the trade name.
    /// </summary>
    public string? TradeName { get; set; }

    /// <summary>
    /// Gets or sets the legal form.
    /// </summary>
    public string? LegalForm { get; set; }

    /// <summary>
    /// Gets or sets the electronic invoicing code.
    /// </summary>
    public string? ElectronicInvoicingCode { get; set; }

    /// <summary>
    /// Gets or sets the commercial register number.
    /// </summary>
    public string? CommercialRegisterNumber { get; set; }

    /// <summary>
    /// Gets or sets the share capital.
    /// </summary>
    public decimal? ShareCapital { get; set; }

    /// <summary>
    /// Gets or sets the currency code.
    /// </summary>
    public string? CurrencyCode { get; set; }

    /// <summary>
    /// Gets or sets the associated party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? Party { get; set; }

    /// <summary>
    /// Gets or sets the warehouses associated with this organization.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<WarehouseOrganization> WarehouseOrganizations { get; set; }
        = [];
}
