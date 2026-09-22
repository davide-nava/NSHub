// <copyright file="ITicketRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for managing support tickets.
/// </summary>
public interface ITicketRepository
{
    /// <summary>
    /// Retrieves a ticket by its strongly-typed identifier including its comments.
    /// </summary>
    Task<Ticket?> GetByIdAsync(TicketId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new ticket aggregate.
    /// </summary>
    Task AddAsync(Ticket ticket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing ticket aggregate.
    /// </summary>
    void Update(Ticket ticket);
}
