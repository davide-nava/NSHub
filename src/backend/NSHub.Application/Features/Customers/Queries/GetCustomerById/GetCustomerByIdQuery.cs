using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;

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

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDto>>
{
    private readonly IApplicationDbContext _context;

    public GetCustomerByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

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
