// <copyright file="CreateTicketCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.Commands.CreateTicket;

using MediatR;
using NSHub.Application.Tickets.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Tickets.Enums;

/// <summary>
/// Command to create a new support ticket.
/// </summary>
public sealed record CreateTicketCommand(
    string Title,
    string Description,
    Guid RequesterId,
    TicketPriority Priority) : IRequest<Result<TicketDto>>;
