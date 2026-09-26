// <copyright file="BaseEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Generic base entity providing a strongly-typed identifier.
/// </summary>
/// <typeparam name="TKey">The primary key type.</typeparam>
public abstract class BaseEntity<TKey>
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public virtual TKey Id { get; set; } = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseEntity{TKey}"/> class.
    /// </summary>
    protected BaseEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseEntity{TKey}"/> class with an identifier.
    /// </summary>
    /// <param name="id">The unique identifier.</param>
    protected BaseEntity(TKey id)
    {
        Id = id;
    }
}

/// <summary>
/// Base entity providing a Guid identifier.
/// </summary>
public abstract class BaseEntity : BaseEntity<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseEntity"/> class.
    /// </summary>
    protected BaseEntity()
        : base(Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseEntity"/> class with an identifier.
    /// </summary>
    /// <param name="id">The unique identifier.</param>
    protected BaseEntity(Guid id)
        : base(id)
    {
    }
}
