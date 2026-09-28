// <copyright file="GetCustomerByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.Customers.Queries.GetCustomerById;

public record CustomerDto(
    Guid Id,
    string Code,
    string CompanyName,
    string? VatNumber,
    string? TaxCode,
    string? Email,
    string? Phone,
    decimal? CreditLimit,
    bool IsActive);

public record GetCustomerByIdQuery(Guid Id) : IRequest<Result<CustomerDto>>;

public class GetCustomerByIdQueryHandler(IRepository<Customer> customerRepository) : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDto>>
{
    public async Task<Result<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (customer == null)
        {
            return Result.Failure<CustomerDto>($"Customer with Id {request.Id} was not found.");
        }

        var dto = new CustomerDto(
            customer.Id,
            customer.Code,
            customer.CompanyName,
            customer.VatNumber,
            customer.TaxCode,
            customer.Email,
            customer.Phone,
            customer.CreditLimit,
            customer.IsActive);

        return Result.Success(dto);
    }
}
