// <copyright file="CreateTicketCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.Commands.CreateTicket;

using FluentValidation;

/// <summary>
/// Validator for <see cref="CreateTicketCommand"/>.
/// </summary>
public sealed class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTicketCommandValidator"/> class.
    /// </summary>
    public CreateTicketCommandValidator()
    {
        _ = RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Ticket title is required.")
            .MaximumLength(200);

        _ = RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Ticket description is required.")
            .MaximumLength(4000);

        _ = RuleFor(x => x.RequesterId)
            .NotEmpty().WithMessage("Requester ID is required.");
    }
}
