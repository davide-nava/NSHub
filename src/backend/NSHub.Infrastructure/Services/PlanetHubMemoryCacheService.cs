// <copyright file="PlanetHubMemoryCacheService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using Microsoft.Extensions.Caching.Memory;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Services;

/// <summary>
/// In-memory cache service implementation for caching keys and options.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NSHubMemoryCacheService"/> class.
/// </remarks>
/// <param name="memoryCache">The underlying memory cache.</param>
public class NSHubMemoryCacheService(IMemoryCache memoryCache) : INSHubMemoryCacheService
{
    /// <inheritdoc/>
    public MemoryCacheEntryOptions Options { get; } = new()
                                                      {
                                                          SlidingExpiration = TimeSpan.FromDays(365),
                                                          AbsoluteExpiration = DateTimeOffset.Now.AddYears(1),
                                                          AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(365),
                                                      };

    /// <inheritdoc/>
    public Collection<string> Keys { get; set; } = [];

    /// <inheritdoc/>
    public MemoryCache Cache { get; set; } = new(
                                                 new MemoryCacheOptions
                                                 {
                                                     //SizeLimit = 1024,
                                                 });

    /// <inheritdoc/>
    public void RemoveContainsKey(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        key = key.ToUpperInvariant();

        foreach (var k in Keys.Where(k => k.ToUpperInvariant()
                                           .Contains(key, StringComparison.CurrentCultureIgnoreCase))
                              .ToList())
        {
            memoryCache.Remove(k);
        }
    }

    /// <inheritdoc/>
    public void RemoveAll()
    {
        foreach (var k in Keys)
        {
            memoryCache.Remove(k);
        }

        Keys.Clear();
    }

    /// <inheritdoc/>
    public string SetKey(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        key = key.ToUpperInvariant();

        if (!Keys.Contains(key))
        {
            Keys.Add(key);
        }

        return key;
    }
}
