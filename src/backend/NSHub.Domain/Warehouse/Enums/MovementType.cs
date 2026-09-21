// <copyright file="MovementType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Warehouse.Enums;

/// <summary>
/// Operational movement types for inventory tracking.
/// </summary>
public enum MovementType
{
    /// <summary>
    /// Inbound reception from supplier or production.
    /// </summary>
    INBOUND = 1,

    /// <summary>
    /// Outbound shipment or customer fulfillment.
    /// </summary>
    OUTBOUND = 2,

    /// <summary>
    /// Internal transfer between stock locations.
    /// </summary>
    TRANSFER = 3,

    /// <summary>
    /// Stock adjustment or inventory cycle count reconciliation.
    /// </summary>
    ADJUSTMENT = 4
}
