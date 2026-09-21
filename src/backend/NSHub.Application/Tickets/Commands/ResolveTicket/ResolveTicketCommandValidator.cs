// <copyright file="ResolveTicketCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.Commands.ResolveTicket;

using FluentValidation;

/// <summary>
/// Validator for <see cref="ResolveTicketCommand"/>.
/// </summary>
public sealed class ResolveTicketCommandValidator : AbstractValidator<ResolveTicketCommand>
{
    public ResolveTicketCommandValidator()
    {
        _ = RuleFor(x => x.TicketId).NotEmpty().WithMessage("Ticket ID is required.");
        _ = RuleFor(x => x.ResolutionNotes).NotEmpty().WithMessage("Resolution notes are required when resolving a ticket.");
    }
}
