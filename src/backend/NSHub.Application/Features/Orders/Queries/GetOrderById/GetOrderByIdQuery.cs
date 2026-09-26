// <copyright file="GetOrderByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;

namespace NSHub.Application.Features.Orders.Queries.GetOrderById;

public record OrderDto(
    Guid Id,
    string OrderNumber,
    int Year,
    DateTime Date,
    string OrderType,
    Guid? CustomerId,
    string StatusCode,
    string CurrencyCode,
    decimal TotalGrossAmount);

public record GetOrderByIdQuery(Guid Id) : IRequest<Result<OrderDto>>;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderDto>>
{
    private readonly IApplicationDbContext _context;

    public GetOrderByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (order == null)
        {
            return Result.Failure<OrderDto>($"Order with Id {request.Id} was not found.");
        }

        var dto = new OrderDto(
            order.Id,
            order.OrderNumber,
            order.Year,
            order.Date,
            order.OrderType,
            order.CustomerId,
            order.StatusCode,
            order.CurrencyCode,
            order.TotalGrossAmount);

        return Result.Success(dto);
    }
}
