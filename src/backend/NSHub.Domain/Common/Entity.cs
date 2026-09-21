// <copyright file="Entity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Generic base entity supporting strongly-typed identifiers and domain event aggregation.
/// </summary>
/// <typeparam name="TId">The strongly-typed identifier type.</typeparam>
public abstract class Entity<TId> where TId : notnull
{
    /// <summary>
    /// Gets the unique strongly-typed identifier of the entity.
    /// </summary>
    public TId Id { get; protected set; } = default!;

    private readonly List<object> _domainEvents = [];

    /// <summary>
    /// Gets an unmodifiable collection of recorded domain events awaiting dispatch.
    /// </summary>
    public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Enqueues a domain event to be dispatched upon persistence.
    /// </summary>
    /// <param name="domainEvent">The domain event payload.</param>
    public void AddDomainEvent(object domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Clears all recorded domain events after successful dispatch.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}
