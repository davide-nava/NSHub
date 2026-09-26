// <copyright file="TransportReasonDeliveryNote.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class TransportReasonDeliveryNote : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;

    protected TransportReasonDeliveryNote() { }

    public static TransportReasonDeliveryNote Create()
    {
        return new TransportReasonDeliveryNote();
    }
}
