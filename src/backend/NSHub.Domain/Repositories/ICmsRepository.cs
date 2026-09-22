// <copyright file="ICmsRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for CMS page and tag persistence.
/// </summary>
public interface ICmsRepository
{
    /// <summary>
    /// Retrieves a page by its identifier including tags.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<Page?> GetByIdAsync(PageId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a page by its unique slug including tags.
    /// </summary>
    /// <param name="slug"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<Page?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks whether a page exists with the specified URL slug.
    /// </summary>
    /// <param name="slug"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<bool> ExistsBySlugAsync(string slug, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new page aggregate.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task AddAsync(Page page, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing page aggregate.
    /// </summary>
    /// <param name="page"></param>
    public void Update(Page page);
}
