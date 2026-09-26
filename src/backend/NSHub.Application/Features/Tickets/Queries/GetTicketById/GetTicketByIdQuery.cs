// <copyright file="GetTicketByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;

namespace NSHub.Application.Features.Tickets.Queries.GetTicketById;

public record TicketDto(
    Guid Id,
    string Title,
    string Description,
    Guid CustomerId,
    Guid? MachineId,
    Guid UserId);

public record GetTicketByIdQuery(Guid Id) : IRequest<Result<TicketDto>>;

public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, Result<TicketDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTicketByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<TicketDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _context.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

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
