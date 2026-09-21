// <copyright file="RecordStockMovementCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Warehouse;

using Moq;
using NSHub.Application.Warehouse.Commands.RecordStockMovement;
using NSHub.Domain.Common;
using NSHub.Domain.Warehouse.Entities;
using NSHub.Domain.Warehouse.Enums;
using NSHub.Domain.Warehouse.Repositories;
using NSHub.Domain.Warehouse.ValueObjects;

public class RecordStockMovementCommandHandlerTests
{
    private readonly Mock<IInventoryRepository> inventoryRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly RecordStockMovementCommandHandler handler;

    public RecordStockMovementCommandHandlerTests()
    {
        handler = new RecordStockMovementCommandHandler(
            inventoryRepositoryMock.Object,
            unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_InboundMovement_ShouldIncreaseStock()
    {
        // Arrange
        var articleId = Guid.NewGuid();
        var destLocationId = Guid.NewGuid();
        var article = new Article(new ArticleId(articleId), "SKU-001", "Widget", "Standard widget", ArticleUnitOfMeasure.Piece);
        var existingStock = new InventoryStock(Guid.NewGuid(), new ArticleId(articleId), new StockLocationId(destLocationId), initialQuantity: 20);

        _ = inventoryRepositoryMock.Setup(r => r.GetArticleByIdAsync(new ArticleId(articleId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(article);
        _ = inventoryRepositoryMock.Setup(r => r.GetStockAsync(new ArticleId(articleId), new StockLocationId(destLocationId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingStock);

        var command = new RecordStockMovementCommand(
            articleId,
            SourceLocationId: null,
            DestinationLocationId: destLocationId,
            Quantity: 15,
            MovementType: MovementType.Inbound,
            ReferenceNumber: "PO-2026-001");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.QuantityOnHand.Should().Be(35);
        inventoryRepositoryMock.Verify(r => r.UpdateStock(existingStock), Times.Once);
        inventoryRepositoryMock.Verify(r => r.AddMovementAsync(It.IsAny<InventoryMovement>(), It.IsAny<CancellationToken>()), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_OutboundMovement_WhenStockInsufficient_ShouldReturnConflict()
    {
        // Arrange
        var articleId = Guid.NewGuid();
        var sourceLocationId = Guid.NewGuid();
        var article = new Article(new ArticleId(articleId), "SKU-001", "Widget", "Standard widget", ArticleUnitOfMeasure.Piece);
        var existingStock = new InventoryStock(Guid.NewGuid(), new ArticleId(articleId), new StockLocationId(sourceLocationId), initialQuantity: 5);

        _ = inventoryRepositoryMock.Setup(r => r.GetArticleByIdAsync(new ArticleId(articleId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(article);
        _ = inventoryRepositoryMock.Setup(r => r.GetStockAsync(new ArticleId(articleId), new StockLocationId(sourceLocationId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingStock);

        var command = new RecordStockMovementCommand(
            articleId,
            SourceLocationId: sourceLocationId,
            DestinationLocationId: null,
            Quantity: 10,
            MovementType: MovementType.Outbound,
            ReferenceNumber: "SO-2026-001");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("Stock.NegativeNotAllowed");
    }
}
