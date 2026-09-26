// <copyright file="IAuditableEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// 
/// </summary>
public interface IAuditableEntity
{
    /// <summary>
    /// 
    /// </summary>
    public DateTime DateInsert { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime? DateDelete { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime DateUpdate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid? UserInsertId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid? UserDeleteId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid? UserUpdateId { get; set; }
}
