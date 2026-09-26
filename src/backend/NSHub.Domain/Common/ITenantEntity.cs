// <copyright file="ITenantEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// 
/// </summary>
public interface ITenantEntity
{
    /// <summary>
    /// 
    /// </summary>
    public Guid? TenantId { get; set; }
}
