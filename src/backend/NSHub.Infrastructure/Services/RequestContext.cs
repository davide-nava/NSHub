// <copyright file="RequestContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Services;

/// <summary>
/// Ambient context holding tenant and user identifiers for the current request.
/// </summary>
public class RequestContext : IRequestContext
public class RequestContext : IRequestContext
{
    /// <inheritdoc/>
    public Guid TenantId { get; set; } = Guid.Empty;

    /// <inheritdoc/>
    public Guid UserId { get; set; } = Guid.Empty;
}
