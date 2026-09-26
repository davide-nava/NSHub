// <copyright file="TransportCareDeliveryNote.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class TransportCareDeliveryNote : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;
    public string? Notes { get; protected set; }

    protected TransportCareDeliveryNote() { }

    public static TransportCareDeliveryNote Create()
    {
        return new TransportCareDeliveryNote();
    }
}
