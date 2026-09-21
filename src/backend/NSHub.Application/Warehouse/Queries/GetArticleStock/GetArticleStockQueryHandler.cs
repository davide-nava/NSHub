// <copyright file="GetArticleStockQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Warehouse.Queries.GetArticleStock;

using MediatR;
using NSHub.Application.Warehouse.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Warehouse.Repositories;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// Handler for <see cref="GetArticleStockQuery"/>.
/// </summary>
public sealed class GetArticleStockQueryHandler(IInventoryRepository inventoryRepository) : IRequestHandler<GetArticleStockQuery, Result<List<ArticleStockDto>>>
{
    public async Task<Result<List<ArticleStockDto>>> Handle(GetArticleStockQuery request, CancellationToken cancellationToken)
    {
        var stocks = await inventoryRepository.GetStockByArticleAsync(new ArticleId(request.ArticleId), cancellationToken);

        var dtos = stocks.Select(s => new ArticleStockDto(
            s.ArticleId.Value,
            s.LocationId.Value,
            s.QuantityOnHand,
            s.QuantityReserved,
            s.AvailableQuantity)).ToList();

        return Result<List<ArticleStockDto>>.Success(dtos);
    }
}
