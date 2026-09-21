// <copyright file="ITenantProvider.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Providers;

/// <summary>
/// Defines a provider for resolving the current tenant identifier.
/// </summary>
public interface ITenantProvider
{
    /// <summary>
    /// Gets the current tenant identifier.
    /// </summary>
    /// <returns>The tenant identifier.</returns>
    Guid GetTenantId();
}
