using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class InterventionUser : AuditableTenantEntity
{
    public string? Notes { get; protected set; }
    public Guid UserId { get; protected set; }
    public Guid InterventionId { get; protected set; }
    public DateTime EndDate { get; protected set; }
    public DateTime StartDate { get; protected set; }
    public virtual Intervention? Intervention { get; protected set; }
    public virtual User? User { get; protected set; }

    protected InterventionUser() { }

    public static InterventionUser Create()
    {
        return new InterventionUser();
    }
}
