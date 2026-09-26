// <copyright file="InterventionUser.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

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
