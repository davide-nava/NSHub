// <copyright file="TicketClosedException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Exceptions;

/// <summary>
/// Exception thrown when attempting to mutate or modify a ticket that is already closed.
/// </summary>
public class TicketClosedException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TicketClosedException"/> class.
    /// </summary>
    /// <param name="ticketId">The ticket identifier.</param>
    public TicketClosedException(Guid ticketId)
        : base("Ticket.Closed", $"Ticket '{ticketId}' is closed and cannot be mutated or receive further comments.")
    {
    }
}
