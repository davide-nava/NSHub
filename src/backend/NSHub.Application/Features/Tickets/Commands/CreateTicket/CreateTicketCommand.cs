// <copyright file="CreateTicketCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using NSHub.Application.Common.Interfaces;
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
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(255).WithMessage("Title must not exceed 255 characters.");

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(v => v.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(v => v.TicketStatusTypeId)
            .NotEmpty().WithMessage("Ticket status type ID is required.");
    }
}

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;

    public CreateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = Ticket.Create(
            request.Title,
            request.Description,
            request.UserId,
            request.TicketStatusTypeId,
            request.CustomerId,
            request.MachineId);

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(ticket.Id);
    }
}
