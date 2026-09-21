// <copyright file="GlJournalLine.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class GlJournalLine
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public Guid? UserUpdateId { get; set; }

    public Guid? UserInsertId { get; set; }

    public DateTime DateUpdate { get; set; }

    public DateTime DateInsert { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public Guid GlJournalId { get; set; }

    public Guid LineNumber { get; set; }

    public Guid GlAccountId { get; set; }

    public Guid? BusinessUnitId { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? SupplierId { get; set; }

    public decimal DebitAmount { get; set; }

    public decimal CreditAmount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal ExchangeRate { get; set; }

    public string? ReferenceDocumentType { get; set; }

    public Guid? ReferenceDocumentId { get; set; }
}
