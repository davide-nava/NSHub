using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using NSHub.Application.Common.Interfaces;
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
        RuleFor(v => v.OrderNumber)
            .NotEmpty().WithMessage("Order number is required.")
            .MaximumLength(50).WithMessage("Order number must not exceed 50 characters.");

        RuleFor(v => v.Year)
            .GreaterThan(2000).WithMessage("Year must be valid.");

        RuleFor(v => v.OrderType)
            .NotEmpty().WithMessage("Order type is required.");

        RuleFor(v => v.CurrencyCode)
            .NotEmpty().Length(3).WithMessage("Currency code must be 3 characters.");
    }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.Create(
            request.OrderNumber,
            request.Year,
            request.Date,
            request.OrderType,
            request.CustomerId,
            request.CurrencyCode,
            request.TotalGrossAmount);

        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(order.Id);
    }
}
