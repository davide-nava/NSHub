// <copyright file="IInvoiceRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for sales invoice persistence.
/// </summary>
public interface IInvoiceRepository
{
    /// <summary>
    /// Retrieves an invoice by its strongly-typed identifier including lines.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<Invoice?> GetByIdAsync(InvoiceId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the highest sequential invoice number issued in a given year.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<int> GetMaxInvoiceSequenceForYearAsync(int year, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new invoice aggregate.
    /// </summary>
    /// <param name="invoice"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task AddAsync(Invoice invoice, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing invoice aggregate.
    /// </summary>
    /// <param name="invoice"></param>
    public void Update(Invoice invoice);
}
