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
public sealed record AssignTicketCommand(
    Guid TicketId,
    Guid TechnicianId) : IRequest<Result<TicketDto>>;
