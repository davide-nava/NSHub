// <copyright file="MovementType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Operational movement types for inventory tracking.
/// </summary>

public enum MovementType
{
    /// <summary>
    /// Inbound reception from supplier or production.
    /// </summary>
    Inbound = 1,

    /// <summary>
    /// Outbound shipment or customer fulfillment.
    /// </summary>
    Outbound = 2,

    /// <summary>
    /// Internal transfer between stock locations.
    /// </summary>
    Transfer = 3,

    /// <summary>
    /// Stock adjustment or inventory cycle count reconciliation.
    /// </summary>
    Adjustment = 4,
}
