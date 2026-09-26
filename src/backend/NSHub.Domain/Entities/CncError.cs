// <copyright file="CncError.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class CncError : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    protected CncError() { }

    public static CncError Create()
    {
        return new CncError();
    }
}
