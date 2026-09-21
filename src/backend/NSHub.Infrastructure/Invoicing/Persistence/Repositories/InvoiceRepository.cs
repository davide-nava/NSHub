// <copyright file="InvoiceRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Invoicing.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Invoicing.Entities;
using NSHub.Domain.Invoicing.Repositories;
using NSHub.Domain.Invoicing.ValueObjects;
using NSHub.Infrastructure.Persistence;

/// <summary>
/// EF Core implementation of <see cref="IInvoiceRepository"/>.
/// </summary>
public class InvoiceRepository(OpenXGestDbContext context) : IInvoiceRepository
{
    /// <inheritdoc />
    public async Task<Invoice?> GetByIdAsync(InvoiceId id, CancellationToken cancellationToken = default)
    {
        return await context.Set<Invoice>()
            .Include(i => i.Lines)
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> GetMaxInvoiceSequenceForYearAsync(int year, CancellationToken cancellationToken = default)
    {
        var prefix = $"INV-{year}-";
        var invoiceNumbers = await context.Set<Invoice>()
            .Where(i => i.InvoiceNumber.StartsWith(prefix))
            .Select(i => i.InvoiceNumber)
            .ToListAsync(cancellationToken);

        var maxSeq = 0;
        foreach (var invNum in invoiceNumbers)
        {
            var parts = invNum.Split('-');
            if (parts.Length == 3 && int.TryParse(parts[2], out var seq) && seq > maxSeq)
            {
                maxSeq = seq;
            }
        }

        return maxSeq;
    }

    /// <inheritdoc />
    public async Task AddAsync(Invoice invoice, CancellationToken cancellationToken = default)
    {
        _ = await context.Set<Invoice>().AddAsync(invoice, cancellationToken);
    }

    /// <inheritdoc />
    public void Update(Invoice invoice)
    {
        if (context.Entry(invoice).State == EntityState.Detached)
        {
            _ = context.Set<Invoice>().Attach(invoice);
        }

        context.Entry(invoice).State = EntityState.Modified;
    }
}
