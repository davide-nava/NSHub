using System;
using System.Collections.Generic;
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
