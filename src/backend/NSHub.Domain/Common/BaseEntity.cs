// <copyright file="BaseEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Represents the abstract base entity providing a unique identifier and domain event management capabilities.
/// </summary>
public abstract class BaseEntity
{
    private readonly List<object> _domainEvents = [];

    /// <summary>
    /// Gets the unique identifier for this entity.
    /// </summary>
    public Guid Id { get; protected set; } = Guid.NewGuid();

    /// <summary>
    /// Gets the read-only collection of domain events dispatched by this entity.
    /// </summary>
    public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Adds a domain event to the entity's event collection.
    /// </summary>
    /// <param name="domainEvent">The domain event to append.</param>
    public void AddDomainEvent(object domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Clears all registered domain events from the entity.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}

