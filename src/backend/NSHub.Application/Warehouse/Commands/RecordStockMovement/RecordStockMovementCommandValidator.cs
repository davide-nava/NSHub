// <copyright file="RecordStockMovementCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Warehouse.Commands.RecordStockMovement;

using FluentValidation;
using NSHub.Domain.Warehouse.Enums;

/// <summary>
/// Validator for <see cref="RecordStockMovementCommand"/>.
/// </summary>
public sealed class RecordStockMovementCommandValidator : AbstractValidator<RecordStockMovementCommand>
{
    public RecordStockMovementCommandValidator()
    {
        _ = RuleFor(x => x.ArticleId).NotEmpty().WithMessage("Article ID is required.");
        _ = RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Movement quantity must be greater than zero.");
        _ = RuleFor(x => x.ReferenceNumber).NotEmpty().MaximumLength(100);

        _ = When(x => x.MovementType == MovementType.Inbound, () =>
        {
            _ = RuleFor(x => x.DestinationLocationId).NotEmpty().WithMessage("Destination location is required for inbound movements.");
        });

        _ = When(x => x.MovementType == MovementType.Outbound, () =>
        {
            _ = RuleFor(x => x.SourceLocationId).NotEmpty().WithMessage("Source location is required for outbound movements.");
        });

        _ = When(x => x.MovementType == MovementType.Transfer, () =>
        {
            _ = RuleFor(x => x.SourceLocationId).NotEmpty().WithMessage("Source location is required for transfers.");
            _ = RuleFor(x => x.DestinationLocationId).NotEmpty().WithMessage("Destination location is required for transfers.");
            _ = RuleFor(x => x).Must(x => x.SourceLocationId != x.DestinationLocationId)
                .WithMessage("Source and destination locations cannot be identical.");
        });
    }
}
