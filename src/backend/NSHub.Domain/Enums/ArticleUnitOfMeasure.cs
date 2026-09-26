// <copyright file="ArticleUnitOfMeasure.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Units of measure supported for inventory articles.
/// </summary>
public enum ArticleUnitOfMeasure
{
    /// <summary>
    /// Discrete unit (Piece / Unit).
    /// </summary>
    Piece = 1,

    /// <summary>
    /// Mass in kilograms.
    /// </summary>
    Kilogram = 2,

    /// <summary>
    /// Length in meters.
    /// </summary>
    Meter = 3,

    /// <summary>
    /// Volume in liters.
    /// </summary>
    Liter = 4,

    /// <summary>
    /// Packaging container (Box).
    /// </summary>
    Box = 5,

    /// <summary>
    /// Time in hours (for labor / service articles).
    /// </summary>
    Hour = 6,
}
