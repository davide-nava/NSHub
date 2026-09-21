// <copyright file="ResolveTicketCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.Commands.ResolveTicket;

using MediatR;
using NSHub.Application.Tickets.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Command to mark a support ticket as resolved with mandatory resolution notes.
/// </summary>
public sealed record ResolveTicketCommand(
    Guid TicketId,
    string ResolutionNotes) : IRequest<Result<TicketDto>>;
