// <copyright file="StockLocation.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing a physical warehouse storage location or bin.
/// </summary>
public class StockLocation : BaseEntity
{
    /// <summary>
    /// Gets the unique location code (e.g. "MAIN-A-01").
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets the display name of the location.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the warehouse code identifying the facility.
    /// </summary>
    public string WarehouseCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets a value indicating whether the location is active.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
