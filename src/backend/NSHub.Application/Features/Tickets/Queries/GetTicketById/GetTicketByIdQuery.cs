// <copyright file="GetTicketByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.Tickets.Queries.GetTicketById;

public record TicketDto(
    Guid Id,
    string Title,
    string Description,
    Guid CustomerId,
    Guid? MachineId,
    Guid UserId);

public record GetTicketByIdQuery(Guid Id) : IRequest<Result<TicketDto>>;

public class GetTicketByIdQueryHandler(IRepository<Ticket> ticketRepository) : IRequestHandler<GetTicketByIdQuery, Result<TicketDto>>
{
    public async Task<Result<TicketDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.GetByIdAsync(request.Id, cancellationToken);

        if (ticket == null)
        {
            return Result.Failure<TicketDto>($"Ticket with Id {request.Id} was not found.");
        }

        var dto = new TicketDto(
            ticket.Id,
            ticket.Title,
            ticket.Description,
            ticket.CustomerId ?? Guid.Empty,
            ticket.MachineId,
            ticket.UserId);

        return Result.Success(dto);
    }
}
