// <copyright file="UnitOfMeasure.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a unit of measure lookup entity.
/// </summary>
public class UnitOfMeasure : BaseLookup
{
    /// <summary>Gets or sets the unit symbol/acronym.</summary>
    public string? Symbol { get; set; }
}
