// <copyright file="CmsRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;
using NSHub.Domain.Repositories;

namespace NSHub.Infrastructure.Cms.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Cms.Entities;
using NSHub.Domain.Cms.ValueObjects;
using NSHub.Infrastructure.Persistence;

/// <summary>
/// EF Core implementation of <see cref="ICmsRepository"/>.
/// </summary>
public class CmsRepository(OpenXGestDbContext context) : ICmsRepository
{
    /// <inheritdoc />
    public async Task<Page?> GetByIdAsync(PageId id, CancellationToken cancellationToken = default)
    {
        return await context.Set<Page>()
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<Page?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        var normalizedSlug = Page.NormalizeSlug(slug);
        return await context.Set<Page>()
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Slug == normalizedSlug, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        var normalizedSlug = Page.NormalizeSlug(slug);
        return await context.Set<Page>()
            .AnyAsync(p => p.Slug == normalizedSlug, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddAsync(Page page, CancellationToken cancellationToken = default)
    {
        _ = await context.Set<Page>().AddAsync(page, cancellationToken);
    }

    /// <inheritdoc />
    public void Update(Page page)
    {
        if (context.Entry(page).State == EntityState.Detached)
        {
            _ = context.Set<Page>().Attach(page);
        }

        context.Entry(page).State = EntityState.Modified;
    }
}
