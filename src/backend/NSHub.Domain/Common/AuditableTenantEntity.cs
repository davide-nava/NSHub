using System;

namespace NSHub.Domain.Common;

public abstract class AuditableTenantEntity : AuditableEntity, ITenantEntity
{
    public Guid? TenantId { get; set; }

    protected AuditableTenantEntity() { }
    protected AuditableTenantEntity(Guid id) : base(id) { }
}
