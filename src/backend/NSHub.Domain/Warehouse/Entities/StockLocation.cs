// <copyright file="StockLocation.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Warehouse.Entities;

using NSHub.Domain.Common;
using NSHub.Domain.Exceptions;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// Domain entity representing a physical warehouse storage location or bin.
/// </summary>
public class StockLocation : Entity<StockLocationId>
{
    /// <summary>
    /// Gets the unique location code (e.g. "MAIN-A-01").
    /// </summary>
    public string Code { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the display name of the location.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the warehouse code identifying the facility.
    /// </summary>
    public string WarehouseCode { get; private set; } = string.Empty;

    /// <summary>
    /// Gets a value indicating whether the location is active.
    /// </summary>
    public bool IsActive { get; private set; } = true;

    // Parameterless constructor for EF Core
    private StockLocation()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StockLocation"/> entity.
    /// </summary>
    public StockLocation(
        StockLocationId id,
        string code,
        string name,
        string warehouseCode)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new BusinessRuleValidationException("StockLocation.CodeRequired", "Location code is mandatory.");
        }

        if (string.IsNullOrWhiteSpace(warehouseCode))
        {
            throw new BusinessRuleValidationException("StockLocation.WarehouseCodeRequired", "Warehouse code is mandatory.");
        }

        Id = id.Value == Guid.Empty ? StockLocationId.New() : id;
        Code = code.Trim().ToUpperInvariant();
        Name = string.IsNullOrWhiteSpace(name) ? Code : name.Trim();
        WarehouseCode = warehouseCode.Trim().ToUpperInvariant();
        IsActive = true;
    }

    /// <summary>
    /// Deactivates the location.
    /// </summary>
    public void Deactivate() => IsActive = false;

    /// <summary>
    /// Activates the location.
    /// </summary>
    public void Activate() => IsActive = true;
}
