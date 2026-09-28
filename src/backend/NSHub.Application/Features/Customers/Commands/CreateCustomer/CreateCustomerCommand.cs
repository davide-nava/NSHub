// <copyright file="CreateCustomerCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
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
        _ = RuleFor(v => v.Code)
            .NotEmpty().WithMessage("Customer code is required.")
            .MaximumLength(256).WithMessage("Customer code must not exceed 256 characters.");

        _ = RuleFor(v => v.CompanyName)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(255).WithMessage("Company name must not exceed 255 characters.");

        _ = RuleFor(v => v.Email)
            .EmailAddress().When(v => !string.IsNullOrEmpty(v.Email))
            .WithMessage("Invalid email format.");
    }
}

public class CreateCustomerCommandHandler(IRepository<Customer> customerRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Code = request.Code,
            CompanyName = request.CompanyName,
            VatNumber = request.VatNumber,
            TaxCode = request.TaxCode,
            Email = request.Email,
            Phone = request.Phone,
            CreditLimit = request.CreditLimit,
            IsActive = true,
        };

        _ = await customerRepository.AddAsync(customer, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(customer.Id);
    }
}
