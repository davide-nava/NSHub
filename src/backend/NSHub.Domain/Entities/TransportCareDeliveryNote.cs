// <copyright file="TransportCareDeliveryNote.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a transport carrier used for delivery notes.
/// </summary>
public class TransportCareDeliveryNote : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the carrier description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the carrier notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the delivery notes associated with this carrier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; }
        = [];
}
