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
/// <param name="Title">The title or summary of the ticket.</param>
/// <param name="Description">The detailed description of the issue or request.</param>
/// <param name="RequesterId">The identifier of the user requesting assistance.</param>
/// <param name="Priority">The initial priority of the ticket.</param>
public sealed record CreateTicketCommand(
    string Title,
    string Description,
    Guid RequesterId,
    TicketPriority Priority) : IRequest<Result<TicketDto>>;
