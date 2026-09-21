// <copyright file="CreateTicketCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.Commands.CreateTicket;

using MediatR;
using NSHub.Application.Tickets.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Tickets.Entities;
using NSHub.Domain.Tickets.Repositories;
using NSHub.Domain.Tickets.ValueObjects;

/// <summary>
/// Handler for <see cref="CreateTicketCommand"/>.
/// </summary>
public sealed class CreateTicketCommandHandler(
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateTicketCommand, Result<TicketDto>>
{
    public async Task<Result<TicketDto>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket(
            TicketId.New(),
            request.Title,
            request.Description,
            request.RequesterId,
            request.Priority);

        await ticketRepository.AddAsync(ticket, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = new TicketDto(
            ticket.Id.Value,
            ticket.Title,
            ticket.Description,
            ticket.RequesterId,
            ticket.AssignedTechnicianId,
            ticket.Priority.ToString(),
            ticket.Status.ToString(),
            ticket.Sla.ResolutionDeadlineUtc,
            ticket.Sla.IsBreached(DateTime.UtcNow),
            ticket.ResolutionNotes,
            ticket.ResolvedAtUtc,
            ticket.ClosedAtUtc,
            ticket.CreatedAtUtc,
            []);

        return Result<TicketDto>.Success(dto);
    }
}
