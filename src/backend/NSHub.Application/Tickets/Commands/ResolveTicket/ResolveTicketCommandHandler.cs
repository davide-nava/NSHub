// <copyright file="ResolveTicketCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.Commands.ResolveTicket;

using MediatR;
using NSHub.Application.Tickets.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Tickets.Repositories;
using NSHub.Domain.Tickets.ValueObjects;

/// <summary>
/// Handler for <see cref="ResolveTicketCommand"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ResolveTicketCommandHandler"/> class.
/// </remarks>
/// <param name="ticketRepository">The ticket repository.</param>
/// <param name="unitOfWork">The unit of work.</param>
public sealed class ResolveTicketCommandHandler(
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<ResolveTicketCommand, Result<TicketDto>>
{
    /// <inheritdoc/>
    public async Task<Result<TicketDto>> Handle(ResolveTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.GetByIdAsync(new TicketId(request.TicketId), cancellationToken);
        if (ticket is null)
        {
            return Result<TicketDto>.Failure(Error.NotFound("Ticket.NotFound", $"Ticket with ID '{request.TicketId}' was not found."));
        }

        ticket.Resolve(request.ResolutionNotes);
        ticketRepository.Update(ticket);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        var commentsDto = ticket.Comments.Select(c => new TicketCommentDto(
            c.Id.Value,
            c.AuthorId,
            c.Message,
            c.CreatedAtUtc,
            c.IsInternalOnly)).ToList();

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
            commentsDto);

        return Result<TicketDto>.Success(dto);
    }
}
