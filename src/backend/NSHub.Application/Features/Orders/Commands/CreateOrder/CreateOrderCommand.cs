// <copyright file="CreateOrderCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    string OrderNumber,
    int Year,
    DateTime Date,
    string OrderType,
    Guid? CustomerId = null,
    string CurrencyCode = "EUR",
    decimal TotalGrossAmount = 0m) : IRequest<Result<Guid>>;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        _ = RuleFor(v => v.OrderNumber)
            .NotEmpty().WithMessage("Order number is required.")
            .MaximumLength(50).WithMessage("Order number must not exceed 50 characters.");

        _ = RuleFor(v => v.Year)
            .GreaterThan(2000).WithMessage("Year must be valid.");

        _ = RuleFor(v => v.OrderType)
            .NotEmpty().WithMessage("Order type is required.");

        _ = RuleFor(v => v.CurrencyCode)
            .NotEmpty().Length(3).WithMessage("Currency code must be 3 characters.");
    }
}

public class CreateOrderCommandHandler(IRepository<Order> orderRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            OrderNumber = request.OrderNumber,
            Year = request.Year,
            Date = request.Date,
            OrderType = request.OrderType,
            CustomerId = request.CustomerId,
            CurrencyCode = request.CurrencyCode,
            TotalGrossAmount = request.TotalGrossAmount,
            StatusCode = "Draft",
        };

        _ = await orderRepository.AddAsync(order, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(order.Id);
    }
}
