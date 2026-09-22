// <copyright file="IInventoryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for inventory articles, locations, stock balances, and ledger movements.
/// </summary>
public interface IInventoryRepository
{
    /// <summary>
    /// Retrieves an article by its identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<Article?> GetArticleByIdAsync(ArticleId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an article by its unique SKU code.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<Article?> GetArticleByCodeAsync(string code, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new article.
    /// </summary>
    /// <param name="article"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task AddArticleAsync(Article article, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing article.
    /// </summary>
    /// <param name="article"></param>
    public void UpdateArticle(Article article);

    /// <summary>
    /// Retrieves a stock location by its identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<StockLocation?> GetLocationByIdAsync(StockLocationId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a stock location by its unique code.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<StockLocation?> GetLocationByCodeAsync(string code, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new stock location.
    /// </summary>
    /// <param name="location"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task AddLocationAsync(StockLocation location, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the stock balance record for a specific article and location.
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="locationId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<InventoryStock?> GetStockAsync(ArticleId articleId, StockLocationId locationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all stock balance records for a given article across all locations.
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<List<InventoryStock>> GetStockByArticleAsync(ArticleId articleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new stock balance entry.
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task AddStockAsync(InventoryStock stock, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing stock balance entry.
    /// </summary>
    /// <param name="stock"></param>
    public void UpdateStock(InventoryStock stock);

    /// <summary>
    /// Appends a new inventory movement to the ledger.
    /// </summary>
    /// <param name="movement"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task AddMovementAsync(InventoryMovement movement, CancellationToken cancellationToken = default);
}
