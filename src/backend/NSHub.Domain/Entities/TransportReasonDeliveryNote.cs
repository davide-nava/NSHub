using System;
using System.Collections.Generic;
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
