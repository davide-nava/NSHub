// <copyright file="InventoryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Warehouse.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Warehouse.Entities;
using NSHub.Domain.Warehouse.Repositories;
using NSHub.Domain.Warehouse.ValueObjects;
using NSHub.Infrastructure.Persistence;

/// <summary>
/// EF Core implementation of <see cref="IInventoryRepository"/>.
/// </summary>
public class InventoryRepository(OpenXGestDbContext context) : IInventoryRepository
{
    /// <inheritdoc />
    public async Task<Article?> GetArticleByIdAsync(ArticleId id, CancellationToken cancellationToken = default)
    {
        return await context.Set<Article>().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<Article?> GetArticleByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var normalizedCode = code.Trim().ToUpperInvariant();
        return await context.Set<Article>().FirstOrDefaultAsync(a => a.Code == normalizedCode, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddArticleAsync(Article article, CancellationToken cancellationToken = default)
    {
        _ = await context.Set<Article>().AddAsync(article, cancellationToken);
    }

    /// <inheritdoc />
    public void UpdateArticle(Article article)
    {
        if (context.Entry(article).State == EntityState.Detached)
        {
            _ = context.Set<Article>().Attach(article);
        }

        context.Entry(article).State = EntityState.Modified;
    }

    /// <inheritdoc />
    public async Task<StockLocation?> GetLocationByIdAsync(StockLocationId id, CancellationToken cancellationToken = default)
    {
        return await context.Set<StockLocation>().FirstOrDefaultAsync(sl => sl.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<StockLocation?> GetLocationByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var normalizedCode = code.Trim().ToUpperInvariant();
        return await context.Set<StockLocation>().FirstOrDefaultAsync(sl => sl.Code == normalizedCode, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddLocationAsync(StockLocation location, CancellationToken cancellationToken = default)
    {
        _ = await context.Set<StockLocation>().AddAsync(location, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<InventoryStock?> GetStockAsync(ArticleId articleId, StockLocationId locationId, CancellationToken cancellationToken = default)
    {
        return await context.Set<InventoryStock>()
            .FirstOrDefaultAsync(s => s.ArticleId == articleId && s.LocationId == locationId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<List<InventoryStock>> GetStockByArticleAsync(ArticleId articleId, CancellationToken cancellationToken = default)
    {
        return await context.Set<InventoryStock>()
            .Where(s => s.ArticleId == articleId)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddStockAsync(InventoryStock stock, CancellationToken cancellationToken = default)
    {
        _ = await context.Set<InventoryStock>().AddAsync(stock, cancellationToken);
    }

    /// <inheritdoc />
    public void UpdateStock(InventoryStock stock)
    {
        if (context.Entry(stock).State == EntityState.Detached)
        {
            _ = context.Set<InventoryStock>().Attach(stock);
        }

        context.Entry(stock).State = EntityState.Modified;
    }

    /// <inheritdoc />
    public async Task AddMovementAsync(InventoryMovement movement, CancellationToken cancellationToken = default)
    {
        _ = await context.Set<InventoryMovement>().AddAsync(movement, cancellationToken);
    }
}
