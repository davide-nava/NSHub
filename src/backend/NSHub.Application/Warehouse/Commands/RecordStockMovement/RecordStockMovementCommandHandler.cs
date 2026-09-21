// <copyright file="RecordStockMovementCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Warehouse.Commands.RecordStockMovement;

using MediatR;
using NSHub.Application.Warehouse.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Exceptions;
using NSHub.Domain.Warehouse.Entities;
using NSHub.Domain.Warehouse.Enums;
using NSHub.Domain.Warehouse.Repositories;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// Handler for <see cref="RecordStockMovementCommand"/>.
/// </summary>
public sealed class RecordStockMovementCommandHandler(
    IInventoryRepository inventoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RecordStockMovementCommand, Result<ArticleStockDto>>
{
    public async Task<Result<ArticleStockDto>> Handle(RecordStockMovementCommand request, CancellationToken cancellationToken)
    {
        var article = await inventoryRepository.GetArticleByIdAsync(new ArticleId(request.ArticleId), cancellationToken);
        if (article is null)
        {
            return Result<ArticleStockDto>.Failure(Error.NotFound("Article.NotFound", $"Article with ID '{request.ArticleId}' was not found."));
        }

        if (!article.IsActive)
        {
            return Result<ArticleStockDto>.Failure(Error.Validation("Article.Inactive", "Cannot perform movements on an inactive article."));
        }

        var sourceLocId = request.SourceLocationId.HasValue ? new StockLocationId(request.SourceLocationId.Value) : (StockLocationId?)null;
        var destLocId = request.DestinationLocationId.HasValue ? new StockLocationId(request.DestinationLocationId.Value) : (StockLocationId?)null;

        InventoryStock? impactedStock = null;

        try
        {
            switch (request.MovementType)
            {
                case MovementType.Inbound:
                    if (!destLocId.HasValue)
                    {
                        return Result<ArticleStockDto>.Failure(Error.Validation("Movement.MissingDestination", "Destination location is required for inbound stock."));
                    }

                    impactedStock = await inventoryRepository.GetStockAsync(article.Id, destLocId.Value, cancellationToken);
                    if (impactedStock is null)
                    {
                        impactedStock = new InventoryStock(Guid.NewGuid(), article.Id, destLocId.Value, request.Quantity);
                        await inventoryRepository.AddStockAsync(impactedStock, cancellationToken);
                    }
                    else
                    {
                        impactedStock.AdjustStock(request.Quantity);
                        inventoryRepository.UpdateStock(impactedStock);
                    }
                    break;

                case MovementType.Outbound:
                    if (!sourceLocId.HasValue)
                    {
                        return Result<ArticleStockDto>.Failure(Error.Validation("Movement.MissingSource", "Source location is required for outbound stock."));
                    }

                    impactedStock = await inventoryRepository.GetStockAsync(article.Id, sourceLocId.Value, cancellationToken);
                    if (impactedStock is null)
                    {
                        return Result<ArticleStockDto>.Failure(Error.NotFound("Stock.NotFound", "Stock balance not found at specified source location."));
                    }

                    impactedStock.AdjustStock(-request.Quantity);
                    inventoryRepository.UpdateStock(impactedStock);
                    break;

                case MovementType.Transfer:
                    if (!sourceLocId.HasValue || !destLocId.HasValue)
                    {
                        return Result<ArticleStockDto>.Failure(Error.Validation("Movement.InvalidLocations", "Both source and destination locations are required for transfer."));
                    }

                    var sourceStock = await inventoryRepository.GetStockAsync(article.Id, sourceLocId.Value, cancellationToken);
                    if (sourceStock is null)
                    {
                        return Result<ArticleStockDto>.Failure(Error.NotFound("Stock.NotFound", "Stock balance not found at specified source location."));
                    }

                    sourceStock.AdjustStock(-request.Quantity);
                    inventoryRepository.UpdateStock(sourceStock);

                    var destStock = await inventoryRepository.GetStockAsync(article.Id, destLocId.Value, cancellationToken);
                    if (destStock is null)
                    {
                        destStock = new InventoryStock(Guid.NewGuid(), article.Id, destLocId.Value, request.Quantity);
                        await inventoryRepository.AddStockAsync(destStock, cancellationToken);
                    }
                    else
                    {
                        destStock.AdjustStock(request.Quantity);
                        inventoryRepository.UpdateStock(destStock);
                    }

                    impactedStock = destStock;
                    break;

                case MovementType.Adjustment:
                    var targetLocationId = destLocId ?? sourceLocId;
                    if (!targetLocationId.HasValue)
                    {
                        return Result<ArticleStockDto>.Failure(Error.Validation("Movement.MissingLocation", "Stock location is required for adjustment."));
                    }

                    impactedStock = await inventoryRepository.GetStockAsync(article.Id, targetLocationId.Value, cancellationToken);
                    if (impactedStock is null)
                    {
                        impactedStock = new InventoryStock(Guid.NewGuid(), article.Id, targetLocationId.Value, request.Quantity);
                        await inventoryRepository.AddStockAsync(impactedStock, cancellationToken);
                    }
                    else
                    {
                        impactedStock.AdjustStock(request.Quantity);
                        inventoryRepository.UpdateStock(impactedStock);
                    }
                    break;
            }

            var movement = new InventoryMovement(
                InventoryMovementId.New(),
                article.Id,
                sourceLocId,
                destLocId,
                request.Quantity,
                request.MovementType,
                request.ReferenceNumber,
                request.Notes);

            await inventoryRepository.AddMovementAsync(movement, cancellationToken);
            _ = await unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = new ArticleStockDto(
                impactedStock!.ArticleId.Value,
                impactedStock.LocationId.Value,
                impactedStock.QuantityOnHand,
                impactedStock.QuantityReserved,
                impactedStock.AvailableQuantity);

            return Result<ArticleStockDto>.Success(dto);
        }
        catch (NegativeStockException ex)
        {
            return Result<ArticleStockDto>.Failure(Error.Conflict("Stock.NegativeNotAllowed", ex.Message));
        }
    }
}
