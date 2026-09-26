// <copyright file="InvoiceType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class InvoiceType : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    private readonly List<Invoice> _invoices = new();
    public virtual IReadOnlyCollection<Invoice> Invoices => _invoices.AsReadOnly();

    protected InvoiceType() { }

    public static InvoiceType Create()
    {
        return new InvoiceType();
    }
}
