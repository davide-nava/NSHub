// <copyright file="CashBook.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class CashBook : AuditableTenantEntity
{
    public DateTime? Date { get; protected set; }
    public decimal? Balance { get; protected set; }
    public string? Notes { get; protected set; }
    public decimal? Credit { get; protected set; }
    public decimal? Debit { get; protected set; }

    protected CashBook() { }

    public static CashBook Create()
    {
        return new CashBook();
    }
}
