// <copyright file="TenantConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.NSHub.Models;

namespace NSHub.Application.Constants;

public static class TenantConstant
{
    public static ConstantValue Demo => new() { Id = new("39C70B59-72CA-4E63-91B4-3548FEF2AE19"), Name = "Demo" };

    public static ConstantValue Test => new() { Id = new("BB45CC04-1C20-4136-8103-C9334E1F425F"), Name = "Test" };

    public static ConstantValue NSHub => new() { Id = new("06FF06E5-7C1A-4448-B85A-A52ADBA03083"), Name = "NSHub" };

    private static readonly List<ConstantValue> tenants =
[
        Demo,
        Test,
        NSHub,
    ];

    public static bool CheckId(Guid id) => tenants.Any(e => e.Id == id);
}

