// <copyright file="AuditableTenantEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Domain.Common;

/// <summary>
/// Represents an auditable entity that is associated with a tenant.
/// </summary>
public abstract class AuditableTenantEntity : AuditableEntity, ITenantEntity
{
    /// <summary>
    /// Gets or sets the identifier of the tenant to which the entity belongs.
    /// </summary>
    public Guid? TenantId { get; set; }

    /// <summary>
    /// Gets or sets the tenant to which the entity belongs.
    /// </summary>
    public virtual Tenant? Tenant { get; set; }
}
