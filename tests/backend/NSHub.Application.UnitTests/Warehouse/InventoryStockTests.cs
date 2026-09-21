// <copyright file="InventoryStockTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Warehouse;

using NSHub.Domain.Exceptions;
using NSHub.Domain.Warehouse.Entities;
using NSHub.Domain.Warehouse.ValueObjects;


public class InventoryStockTests
{
    [Fact]
    public void AdjustStock_WhenProjectedStockNegative_ShouldThrowNegativeStockException()
    {
        // Arrange
        var articleId = ArticleId.New();
        var locationId = StockLocationId.New();
        var stock = new InventoryStock(Guid.NewGuid(), articleId, locationId, initialQuantity: 10);

        // Act
        var act = () => stock.AdjustStock(-15);

        // Assert
        _ = act.Should().Throw<NegativeStockException>()
            .WithMessage("*Insufficient stock*");
    }

    [Fact]
    public void AdjustStock_WithPositiveDelta_ShouldIncreaseQuantityOnHand()
    {
        // Arrange
        var stock = new InventoryStock(Guid.NewGuid(), ArticleId.New(), StockLocationId.New(), initialQuantity: 10);

        // Act
        stock.AdjustStock(5);

        // Assert
        _ = stock.QuantityOnHand.Should().Be(15);
        _ = stock.AvailableQuantity.Should().Be(15);
    }

    [Fact]
    public void ReserveStock_WhenInsufficientAvailable_ShouldThrowNegativeStockException()
    {
        // Arrange
        var stock = new InventoryStock(Guid.NewGuid(), ArticleId.New(), StockLocationId.New(), initialQuantity: 10);
        stock.ReserveStock(8); // Available = 2

        // Act
        var act = () => stock.ReserveStock(5); // Requesting 5 when only 2 available

        // Assert
        _ = act.Should().Throw<NegativeStockException>();
    }

    [Fact]
    public void ReserveStock_WithSufficientStock_ShouldIncreaseReservedQuantity()
    {
        // Arrange
        var stock = new InventoryStock(Guid.NewGuid(), ArticleId.New(), StockLocationId.New(), initialQuantity: 10);

        // Act
        stock.ReserveStock(4);

        // Assert
        _ = stock.QuantityOnHand.Should().Be(10);
        _ = stock.QuantityReserved.Should().Be(4);
        _ = stock.AvailableQuantity.Should().Be(6);
    }

    [Fact]
    public void ReleaseReservation_WhenExceedingReserved_ShouldThrowBusinessRuleValidationException()
    {
        // Arrange
        var stock = new InventoryStock(Guid.NewGuid(), ArticleId.New(), StockLocationId.New(), initialQuantity: 10);
        stock.ReserveStock(3);

        // Act
        var act = () => stock.ReleaseReservation(5);

        // Assert
        _ = act.Should().Throw<BusinessRuleValidationException>()
            .WithMessage("*Cannot release more quantity*");
    }
}
