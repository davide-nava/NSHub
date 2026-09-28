// <copyright file="ConstantValue.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Models;

/// <summary>
/// Represents a reusable constant value identified by a unique identifier,
/// name, description, and ordering index.
/// </summary>
public record ConstantValue
{
    /// <summary>
    /// Gets the description associated with the constant value.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Gets the name of the constant value.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Gets the unique identifier of the constant value.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the ordering index of the constant value.
    /// </summary>
    public int Index { get; init; }
}
