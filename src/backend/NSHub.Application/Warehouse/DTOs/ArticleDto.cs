// <copyright file="ArticleDto.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Warehouse.DTOs;

/// <summary>
/// Data transfer object for an inventory article.
/// </summary>
public sealed record ArticleDto(
    Guid Id,
    string Code,
    string Name,
    string Description,
    string UnitOfMeasure,
    bool IsActive);

/// <summary>
/// Data transfer object for an article stock balance.
/// </summary>
public sealed record ArticleStockDto(
    Guid ArticleId,
    Guid LocationId,
    decimal QuantityOnHand,
    decimal QuantityReserved,
    decimal AvailableQuantity);
