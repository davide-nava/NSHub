// <copyright file="IInventoryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Warehouse.Repositories;

using NSHub.Domain.Warehouse.Entities;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// Repository contract for inventory articles, locations, stock balances, and ledger movements.
/// </summary>
public interface IInventoryRepository
{
    /// <summary>
    /// Retrieves an article by its identifier.
    /// </summary>
    Task<Article?> GetArticleByIdAsync(ArticleId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an article by its unique SKU code.
    /// </summary>
    Task<Article?> GetArticleByCodeAsync(string code, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new article.
    /// </summary>
    Task AddArticleAsync(Article article, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing article.
    /// </summary>
    void UpdateArticle(Article article);

    /// <summary>
    /// Retrieves a stock location by its identifier.
    /// </summary>
    Task<StockLocation?> GetLocationByIdAsync(StockLocationId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a stock location by its unique code.
    /// </summary>
    Task<StockLocation?> GetLocationByCodeAsync(string code, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new stock location.
    /// </summary>
    Task AddLocationAsync(StockLocation location, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the stock balance record for a specific article and location.
    /// </summary>
    Task<InventoryStock?> GetStockAsync(ArticleId articleId, StockLocationId locationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all stock balance records for a given article across all locations.
    /// </summary>
    Task<List<InventoryStock>> GetStockByArticleAsync(ArticleId articleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new stock balance entry.
    /// </summary>
    Task AddStockAsync(InventoryStock stock, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing stock balance entry.
    /// </summary>
    void UpdateStock(InventoryStock stock);

    /// <summary>
    /// Appends a new inventory movement to the ledger.
    /// </summary>
    Task AddMovementAsync(InventoryMovement movement, CancellationToken cancellationToken = default);
}
