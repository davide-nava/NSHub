// <copyright file="AssignTicketCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.Commands.AssignTicket;

using FluentValidation;

/// <summary>
/// Validator for <see cref="AssignTicketCommand"/>.
/// </summary>
public sealed class AssignTicketCommandValidator : AbstractValidator<AssignTicketCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssignTicketCommandValidator"/> class.
    /// </summary>
    public AssignTicketCommandValidator()
    {
        _ = RuleFor(x => x.TicketId).NotEmpty().WithMessage("Ticket ID is required.");
        _ = RuleFor(x => x.TechnicianId).NotEmpty().WithMessage("Technician ID is required.");
    }
}
