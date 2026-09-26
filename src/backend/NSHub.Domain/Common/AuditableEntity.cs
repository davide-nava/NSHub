// <copyright file="AuditableEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class AuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity, ISoftDeletable, IHasRowVersion
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

    /// <summary>
    /// 
    /// </summary>
    public byte[] RowVersion { get; set; } = [];

    /// <summary>
    /// 
    /// </summary>
    protected AuditableEntity()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    protected AuditableEntity(TKey id)
        : base(id)
    {
    }
}

/// <summary>
/// 
/// </summary>
public abstract class AuditableEntity : AuditableEntity<Guid>
{
    /// <summary>
    /// 
    /// </summary>
    protected AuditableEntity()
        : base(Guid.NewGuid())
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    protected AuditableEntity(Guid id)
        : base(id)
    {
    }
}
