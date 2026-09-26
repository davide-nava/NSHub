using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Brand : AuditableTenantEntity
{

    protected Brand() { }

    public static Brand Create()
    {
        return new Brand();
    }
}
