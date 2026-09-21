// <copyright file="IPlanetHubMemoryCacheService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using Microsoft.Extensions.Caching.Memory;

namespace NSHub.Application.Interfaces;

public interface INSHubMemoryCacheService
{
    MemoryCache Cache { get; set; }

    Collection<string> Keys { get; set; }

    MemoryCacheEntryOptions Options { get; }

    void RemoveAll();

    void RemoveContainsKey(string key);

    string SetKey(string key);
}
