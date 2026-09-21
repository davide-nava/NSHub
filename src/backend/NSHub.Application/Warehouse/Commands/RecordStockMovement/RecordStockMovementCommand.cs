// <copyright file="RecordStockMovementCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Warehouse.Commands.RecordStockMovement;

using MediatR;
using NSHub.Application.Warehouse.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Warehouse.Enums;

/// <summary>
/// Command to execute and record an inventory stock movement in the ledger.
/// </summary>
public sealed record RecordStockMovementCommand(
    Guid ArticleId,
    Guid? SourceLocationId,
    Guid? DestinationLocationId,
    decimal Quantity,
    MovementType MovementType,
    string ReferenceNumber,
    string? Notes = null) : IRequest<Result<ArticleStockDto>>;
