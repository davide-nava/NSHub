// <copyright file="ITenantEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Domain.Common;

/// <summary>
/// Defines an entity that belongs to a tenant.
/// </summary>
public interface ITenantEntity
{
    /// <summary>
    /// Gets or sets the identifier of the tenant to which the entity belongs.
    /// </summary>
    public Guid? TenantId { get; set; }

    /// <summary>
    /// Gets or sets the tenant to which the entity belongs.
    /// </summary>
    public Tenant? Tenant { get; set; }
}
