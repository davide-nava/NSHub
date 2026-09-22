// <copyright file="IInvoiceRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for sales invoice persistence.
/// </summary>
public interface IInvoiceRepository
{
    /// <summary>
    /// Retrieves an invoice by its strongly-typed identifier including lines.
    /// </summary>
    Task<Invoice?> GetByIdAsync(InvoiceId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the highest sequential invoice number issued in a given year.
    /// </summary>
    Task<int> GetMaxInvoiceSequenceForYearAsync(int year, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new invoice aggregate.
    /// </summary>
    Task AddAsync(Invoice invoice, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing invoice aggregate.
    /// </summary>
    void Update(Invoice invoice);
}
