// <copyright file="AuditableTenantEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// 
/// </summary>
public abstract class AuditableTenantEntity : AuditableEntity, ITenantEntity
{
    /// <summary>
    /// 
    /// </summary>
    public Guid? TenantId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected AuditableTenantEntity()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    protected AuditableTenantEntity(Guid id)
        : base(id)
    {
    }
}
