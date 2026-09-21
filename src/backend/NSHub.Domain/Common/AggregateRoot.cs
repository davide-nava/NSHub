// <copyright file="AggregateRoot.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Base class for Aggregate Roots in Domain-Driven Design enforcing consistency boundaries.
/// </summary>
/// <typeparam name="TId">The strongly-typed identifier type.</typeparam>
public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot where TId : notnull
{
}
