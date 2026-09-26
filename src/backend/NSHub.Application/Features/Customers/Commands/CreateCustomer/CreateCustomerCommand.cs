// <copyright file="CreateCustomerCommand.cs" company="Davide Nava">
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

namespace NSHub.Application.Features.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(
    string Code,
    string CompanyName,
    string? VatNumber = null,
    string? TaxCode = null,
    string? Email = null,
    string? Phone = null,
    decimal? CreditLimit = null) : IRequest<Result<Guid>>;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(v => v.Code)
            .NotEmpty().WithMessage("Customer code is required.")
            .MaximumLength(256).WithMessage("Customer code must not exceed 256 characters.");

        RuleFor(v => v.CompanyName)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(255).WithMessage("Company name must not exceed 255 characters.");

        RuleFor(v => v.Email)
            .EmailAddress().When(v => !string.IsNullOrEmpty(v.Email))
            .WithMessage("Invalid email format.");
    }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;

    public CreateCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            request.Code,
            request.CompanyName,
            request.VatNumber,
            request.TaxCode,
            request.Email,
            request.Phone,
            request.CreditLimit);

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(customer.Id);
    }
}
