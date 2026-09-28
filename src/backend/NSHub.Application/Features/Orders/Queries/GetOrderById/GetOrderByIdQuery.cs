// <copyright file="GetOrderByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Domain.Entities;

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

public class GetOrderByIdQueryHandler(IRepository<Order> orderRepository) : IRequestHandler<GetOrderByIdQuery, Result<OrderDto>>
{
    public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.Id, cancellationToken);

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
