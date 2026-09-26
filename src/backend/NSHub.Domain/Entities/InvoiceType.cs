// <copyright file="InvoiceType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an invoice type.
/// </summary>
public class InvoiceType : AuditableTenantEntity
{
    /// <summary>
    /// Gets the invoice type description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the invoice type code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the invoices associated with this invoice type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Invoice> Invoices { get; protected set; }
        = new List<Invoice>();
}
