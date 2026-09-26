// <copyright file="Payment.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a payment term.
/// </summary>
public class Payment : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the payment term description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the number of days before payment is due.
    /// </summary>
    public int? Days { get; set; }

    /// <summary>
    /// Gets or sets the suppliers associated with this payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Supplier> Suppliers { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the quotations associated with this payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Quotation> Quotations { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the invoices associated with this payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Invoice> Invoices { get; set; }
        = [];
}
