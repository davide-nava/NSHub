// <copyright file="Brand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

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
