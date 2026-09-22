// <copyright file="TicketRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;
using NSHub.Domain.Repositories;

namespace NSHub.Infrastructure.Tickets.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Tickets.ValueObjects;
using NSHub.Infrastructure.Persistence;

/// <summary>
/// EF Core implementation of <see cref="ITicketCommandRepository"/>.
/// </summary>
public class TicketRepository(OpenXGestDbContext context) : ITicketCommandRepository
{
    /// <inheritdoc />
    public async Task<Ticket?> GetByIdAsync(TicketId id, CancellationToken cancellationToken = default)
    {
        return await context.Set<Ticket>()
            .Include(t => t.Comments)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddAsync(Ticket ticket, CancellationToken cancellationToken = default)
    {
        _ = await context.Set<Ticket>().AddAsync(ticket, cancellationToken);
    }

    /// <inheritdoc />
    public void Update(Ticket ticket)
    {
        if (context.Entry(ticket).State == EntityState.Detached)
        {
            _ = context.Set<Ticket>().Attach(ticket);
        }

        context.Entry(ticket).State = EntityState.Modified;
    }
}
