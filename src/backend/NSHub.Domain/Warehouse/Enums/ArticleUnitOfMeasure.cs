// <copyright file="ArticleUnitOfMeasure.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Warehouse.Enums;

/// <summary>
/// Units of measure supported for inventory articles.
/// </summary>
public enum ArticleUnitOfMeasure
{
    /// <summary>
    /// Discrete unit (Piece / Unit).
    /// </summary>
    PIECE = 1,

    /// <summary>
    /// Mass in kilograms.
    /// </summary>
    KILOGRAM = 2,

    /// <summary>
    /// Length in meters.
    /// </summary>
    METER = 3,

    /// <summary>
    /// Volume in liters.
    /// </summary>
    LITER = 4,

    /// <summary>
    /// Packaging container (Box).
    /// </summary>
    BOX = 5,

    /// <summary>
    /// Time in hours (for labor / service articles).
    /// </summary>
    HOUR = 6
}
