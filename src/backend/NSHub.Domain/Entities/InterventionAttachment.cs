using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class InterventionAttachment : AuditableTenantEntity
{
    public Guid InterventionId { get; protected set; }
    public string Src { get; protected set; } = string.Empty;
    public string Title { get; protected set; } = string.Empty;
    public virtual Intervention? Intervention { get; protected set; }

    protected InterventionAttachment() { }

    public static InterventionAttachment Create()
    {
        return new InterventionAttachment();
    }
}
