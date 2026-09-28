// <copyright file="CreateTicketCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.Tickets.Commands.CreateTicket;

public record CreateTicketCommand(
    string Title,
    string Description,
    Guid UserId,
    Guid TicketStatusTypeId,
    Guid? CustomerId = null,
    Guid? MachineId = null) : IRequest<Result<Guid>>;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        _ = RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(255).WithMessage("Title must not exceed 255 characters.");

        _ = RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required.");

        _ = RuleFor(v => v.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        _ = RuleFor(v => v.TicketStatusTypeId)
            .NotEmpty().WithMessage("Ticket status type ID is required.");
    }
}

public class CreateTicketCommandHandler(IRepository<Ticket> ticketRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateTicketCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            Title = request.Title,
            Description = request.Description,
            UserId = request.UserId,
            TicketStatusTypeId = request.TicketStatusTypeId,
            CustomerId = request.CustomerId,
            MachineId = request.MachineId,
            OpeningDate = DateTime.UtcNow,
        };

        _ = await ticketRepository.AddAsync(ticket, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(ticket.Id);
    }
}
