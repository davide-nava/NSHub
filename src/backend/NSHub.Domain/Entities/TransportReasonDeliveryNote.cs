// <copyright file="TransportReasonDeliveryNote.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a transport reason associated with a delivery note.
/// </summary>
public class TransportReasonDeliveryNote : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the description of the transport reason.
    /// </summary>
    public string Description { get; set; } = string.Empty;
}
