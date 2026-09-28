// <copyright file="IInvoiceNumberSequenceService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Invoicing.Services;

/// <summary>
/// Domain service contract for generating consecutive, legally compliant invoice numbers.
/// </summary>
public interface IInvoiceNumberSequenceService
{
    /// <summary>
    /// Generates the next sequential invoice number for a given fiscal year.
    /// </summary>
    /// <param name="year">The calendar/fiscal year.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The formatted invoice number string (e.g. "INV-2026-00001").</returns>
    Task<string> GetNextInvoiceNumberAsync(int year, CancellationToken cancellationToken = default);
}
