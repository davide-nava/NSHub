// <copyright file="InventoryStock.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Exceptions;

namespace NSHub.Domain.Entities;

/// <summary>
/// Aggregate root representing the current stock balance of an article at a specific warehouse location.
/// Strictly prevents negative available or on-hand stock balances.
/// </summary>
public class InventoryStock : AggregateRoot<Guid>
{
    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    public ArticleId ArticleId { get; set; }

    /// <summary>
    /// Gets the warehouse location identifier.
    /// </summary>
    public StockLocationId LocationId { get; set; }

    /// <summary>
    /// Gets the physical quantity on hand.
    /// </summary>
    public decimal QuantityOnHand { get; set; }

    /// <summary>
    /// Gets the reserved quantity committed to open orders.
    /// </summary>
    public decimal QuantityReserved { get; set; }

    /// <summary>
    /// Gets the free available stock quantity.
    /// </summary>
    public decimal AvailableQuantity => QuantityOnHand - QuantityReserved;

    // Parameterless constructor for EF Core
    private InventoryStock()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryStock"/> aggregate root.
    /// </summary>
    public InventoryStock(
        Guid id,
        ArticleId articleId,
        StockLocationId locationId,
        decimal initialQuantity = 0)
    {
        if (initialQuantity < 0)
        {
            throw new NegativeStockException(articleId.ToString(), locationId.ToString(), 0, initialQuantity);
        }

        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        ArticleId = articleId;
        LocationId = locationId;
        QuantityOnHand = initialQuantity;
        QuantityReserved = 0;
    }

    /// <summary>
    /// Mutates the physical on-hand stock quantity, rejecting transactions that would cause a negative balance.
    /// </summary>
    /// <param name="quantityDelta">The quantity change (positive for inbound, negative for outbound).</param>
    public void AdjustStock(decimal quantityDelta)
    {
        var projected = QuantityOnHand + quantityDelta;
        if (projected < 0)
        {
            throw new NegativeStockException(ArticleId.ToString(), LocationId.ToString(), QuantityOnHand, quantityDelta);
        }

        QuantityOnHand = projected;
    }

    /// <summary>
    /// Reserves stock for an order, ensuring adequate unreserved stock is available.
    /// </summary>
    /// <param name="quantityToReserve">The quantity to reserve.</param>
    public void ReserveStock(decimal quantityToReserve)
    {
        if (quantityToReserve <= 0)
        {
            throw new BusinessRuleValidationException("Stock.InvalidReservation", "Reserved quantity must be strictly positive.");
        }

        if (AvailableQuantity < quantityToReserve)
        {
            throw new NegativeStockException(ArticleId.ToString(), LocationId.ToString(), AvailableQuantity, -quantityToReserve);
        }

        QuantityReserved += quantityToReserve;
    }

    /// <summary>
    /// Releases a previously held stock reservation.
    /// </summary>
    /// <param name="quantityToRelease">The quantity to release.</param>
    public void ReleaseReservation(decimal quantityToRelease)
    {
        if (quantityToRelease <= 0)
        {
            throw new BusinessRuleValidationException("Stock.InvalidRelease", "Released quantity must be strictly positive.");
        }

        if (QuantityReserved < quantityToRelease)
        {
            throw new BusinessRuleValidationException("Stock.ExceedsReserved", "Cannot release more quantity than currently reserved.");
        }

        QuantityReserved -= quantityToRelease;
    }
}
