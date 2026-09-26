using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class WarehouseOrganization : AuditableTenantEntity
{
    public Guid WarehouseId { get; protected set; }
    public Guid OrganizationId { get; protected set; }
    public virtual Organization? Organization { get; protected set; }
    public virtual Warehouse? Warehouse { get; protected set; }

    protected WarehouseOrganization() { }

    public static WarehouseOrganization Create()
    {
        return new WarehouseOrganization();
    }
}
