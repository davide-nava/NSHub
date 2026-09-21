// <copyright file="ICmsRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Cms.Repositories;

using NSHub.Domain.Cms.Entities;
using NSHub.Domain.Cms.ValueObjects;

/// <summary>
/// Repository contract for CMS page and tag persistence.
/// </summary>
public interface ICmsRepository
{
    /// <summary>
    /// Retrieves a page by its identifier including tags.
    /// </summary>
    Task<Page?> GetByIdAsync(PageId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a page by its unique slug including tags.
    /// </summary>
    Task<Page?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks whether a page exists with the specified URL slug.
    /// </summary>
    Task<bool> ExistsBySlugAsync(string slug, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new page aggregate.
    /// </summary>
    Task AddAsync(Page page, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing page aggregate.
    /// </summary>
    void Update(Page page);
}
