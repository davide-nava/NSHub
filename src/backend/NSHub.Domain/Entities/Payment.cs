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
    /// Gets the payment term description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the number of days before payment is due.
    /// </summary>
    public int? Days { get; protected set; }

    /// <summary>
    /// Gets the suppliers associated with this payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Supplier> Suppliers { get; protected set; }
        = new List<Supplier>();

    /// <summary>
    /// Gets the quotations associated with this payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Quotation> Quotations { get; protected set; }
        = new List<Quotation>();

    /// <summary>
    /// Gets the invoices associated with this payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Invoice> Invoices { get; protected set; }
        = new List<Invoice>();
}
