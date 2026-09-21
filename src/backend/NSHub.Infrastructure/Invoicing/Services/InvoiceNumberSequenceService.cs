// <copyright file="InvoiceNumberSequenceService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Invoicing.Services;

using NSHub.Domain.Invoicing.Repositories;
using NSHub.Domain.Invoicing.Services;

/// <summary>
/// Sequence service generating formatted sequential invoice numbers.
/// </summary>
public class InvoiceNumberSequenceService(IInvoiceRepository invoiceRepository) : IInvoiceNumberSequenceService
{
    /// <inheritdoc />
    public async Task<string> GetNextInvoiceNumberAsync(int year, CancellationToken cancellationToken = default)
    {
        var currentMax = await invoiceRepository.GetMaxInvoiceSequenceForYearAsync(year, cancellationToken);
        var nextSeq = currentMax + 1;
        return $"INV-{year}-{nextSeq:D5}";
    }
}
