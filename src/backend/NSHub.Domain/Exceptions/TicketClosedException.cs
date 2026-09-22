// <copyright file="TicketClosedException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Exceptions;

/// <summary>
/// Exception thrown when attempting to mutate or modify a ticket that is already closed.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="TicketClosedException"/> class.
/// </remarks>
/// <param name="ticketId">The ticket identifier.</param>
public class TicketClosedException(Guid ticketId) : DomainException("Ticket.Closed", $"Ticket '{ticketId}' is closed and cannot be mutated or receive further comments.");
