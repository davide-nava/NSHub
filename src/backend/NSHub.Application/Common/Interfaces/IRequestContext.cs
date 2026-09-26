// <copyright file="IRequestContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Provides ambient context information for the current HTTP or background execution request.
/// </summary>
public interface IRequestContext
{
    /// <summary>
    /// Gets or sets the unique identifier of the tenant associated with the current request.
    /// </summary>
    Guid TenantId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the authenticated user associated with the current request.
    /// </summary>
    Guid UserId { get; set; }
}
