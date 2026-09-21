// <copyright file="AssignTicketCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.Commands.AssignTicket;

using MediatR;
using NSHub.Application.Tickets.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Command to assign a support technician to a ticket.
/// </summary>
/// <param name="TicketId">The unique identifier of the ticket.</param>
/// <param name="TechnicianId">The unique identifier of the assigned technician.</param>
public sealed record AssignTicketCommand(
    Guid TicketId,
    Guid TechnicianId) : IRequest<Result<TicketDto>>;
