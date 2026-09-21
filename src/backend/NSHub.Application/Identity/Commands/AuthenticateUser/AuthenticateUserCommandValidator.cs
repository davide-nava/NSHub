// <copyright file="AuthenticateUserCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Identity.Commands.AuthenticateUser;

using FluentValidation;

/// <summary>
/// Validator for <see cref="AuthenticateUserCommand"/>.
/// </summary>
public sealed class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateUserCommandValidator()
    {
        _ = RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.");

        _ = RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}
