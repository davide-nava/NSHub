// <copyright file="InventoryMovement.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Enums;
using NSHub.Domain.Exceptions;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing an immutable ledger record of an inventory movement.
/// </summary>
public class InventoryMovement : Entity<InventoryMovementId>
{
    /// <summary>
    /// Gets the moved article identifier.
    /// </summary>
    public ArticleId ArticleId { get; set; }

    /// <summary>
    /// Gets the source stock location, if applicable (e.g. outbound, transfer).
    /// </summary>
    public StockLocationId? SourceLocationId { get; set; }

    /// <summary>
    /// Gets the destination stock location, if applicable (e.g. inbound, transfer).
    /// </summary>
    public StockLocationId? DestinationLocationId { get; set; }

    /// <summary>
    /// Gets the transferred quantity.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Gets the operational movement classification.
    /// </summary>
    public MovementType Type { get; set; }

    /// <summary>
    /// Gets the external document or tracking reference number (e.g., PO-12345, SO-98765).
    /// </summary>
    public string ReferenceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets the UTC timestamp when the movement was executed.
    /// </summary>
    public DateTime TimestampUtc { get; set; }

    /// <summary>
    /// Gets optional operator notes.
    /// </summary>
    public string? Notes { get; set; }

    // Parameterless constructor for EF Core
    private InventoryMovement()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryMovement"/> ledger entry.
    /// </summary>
    public InventoryMovement(
        InventoryMovementId id,
        ArticleId articleId,
        StockLocationId? sourceLocationId,
        StockLocationId? destinationLocationId,
        decimal quantity,
        MovementType type,
        string referenceNumber,
        string? notes = null)
    {
        if (quantity <= 0)
        {
            throw new BusinessRuleValidationException("Movement.InvalidQuantity", "Movement quantity must be strictly positive.");
        }

        Id = id.Value == Guid.Empty ? InventoryMovementId.New() : id;
        ArticleId = articleId;
        SourceLocationId = sourceLocationId;
        DestinationLocationId = destinationLocationId;
        Quantity = quantity;
        Type = type;
        ReferenceNumber = referenceNumber?.Trim() ?? string.Empty;
        TimestampUtc = DateTime.UtcNow;
        Notes = notes?.Trim();
    }
}
