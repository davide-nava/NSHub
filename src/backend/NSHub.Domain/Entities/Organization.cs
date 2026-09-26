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
    /// Gets the legal name.
    /// </summary>
    public string LegalName { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the trade name.
    /// </summary>
    public string? TradeName { get; protected set; }

    /// <summary>
    /// Gets the legal form.
    /// </summary>
    public string? LegalForm { get; protected set; }

    /// <summary>
    /// Gets the electronic invoicing code.
    /// </summary>
    public string? ElectronicInvoicingCode { get; protected set; }

    /// <summary>
    /// Gets the commercial register number.
    /// </summary>
    public string? CommercialRegisterNumber { get; protected set; }

    /// <summary>
    /// Gets the share capital.
    /// </summary>
    public decimal? ShareCapital { get; protected set; }

    /// <summary>
    /// Gets the currency code.
    /// </summary>
    public string? CurrencyCode { get; protected set; }

    /// <summary>
    /// Gets the associated party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? Party { get; protected set; }

    /// <summary>
    /// Gets the warehouses associated with this organization.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<WarehouseOrganization> WarehouseOrganizations { get; protected set; }
        = new List<WarehouseOrganization>();
}
